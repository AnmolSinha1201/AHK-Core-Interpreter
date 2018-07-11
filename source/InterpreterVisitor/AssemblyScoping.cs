using System.Reflection;
using static AHKCore.Nodes;
using System;
using System.Linq;
using static AHKCore.IndexedNodesFragment.Variables;
using System.Collections.Generic;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		object scopeAssemblyVariable(object scope, variableClass v)
		{
			
			if (scope is IndexedNode ind)
			{
				if (v.extraInfo != null)
					return ((VariableValue)v.extraInfo).Value;
				else if (assemblyMap.Type.Exists(v.variableName))
					return assemblyMap.Type[v.variableName];
			}
			
			else if (scope is Type t)
				return t.GetNestedTypes()
					.Where(i => i.Name.ToLower() == v.variableName.ToLower())?.First();
			else //for instance of type
				return scope.GetType().GetFields()
					.Where(i => i.Name.ToLower() == v.variableName.ToLower())?.First();
			
			return null;
		}
		
		object invokeAssemblyMethod(object scope, functionCallClass func)
		{
			MethodInfo[] MethodArray = null;
			if (scope == null)
			{
				if (!assemblyMap.Method.Exists(func.functionName))
					return null;
				MethodArray = assemblyMap.Method[func.functionName].ToArray();
			}
			else if (scope is Type t)
				MethodArray = t.GetMethods();
			else
				MethodArray = scope.GetType().GetMethods();
			
			var method = MethodArray.Where(i => i.Name.ToLower() == func.functionName.ToLower() 
				&& i.GetParameters().Count() == func.functionParameterList.Count)
				.First();
			
			var assemblyParameters = prepareAssemblyParameters(method, func.functionParameterList);
			var retVal = method.Invoke(scope is Type? null : scope, assemblyParameters);

			var methodParams = method.GetParameters();
			for (int i = 0; i < methodParams.Count(); i++)
			{
				if (!methodParams[i].ParameterType.IsByRef)
					continue;
				if (func.functionParameterList[i] is complexVariableClass o)
					((VariableValue)o.extraInfo).Value = assemblyParameters[i];
			}

			return retVal;					
		}

		object[] prepareAssemblyParameters(MethodInfo method, List<BaseAHKNode> functionParameterList)
		{
			if (method.GetParameters().Count() == functionParameterList.Count)
				return prepareAssemblyParameters1(method, functionParameterList);
			return null;
		}

		// equal param count
		object[] prepareAssemblyParameters1(MethodInfo method, List<BaseAHKNode> functionParameterList)
		{
			var retList = new List<object>();
			var methodParams = method.GetParameters();

			for (int i = 0; i < functionParameterList.Count; i++)
			{
				traverser.objectDispatcher(functionParameterList[i]);
				switch (functionParameterList[i])
				{
					case complexVariableClass o:
						retList.Add(((VariableValue)o.extraInfo).Value);
					break;

					default:
						retList.Add(functionParameterList[i].extraInfo);
					break;
				}
			}

			return retList.ToArray();
		}
	}
}