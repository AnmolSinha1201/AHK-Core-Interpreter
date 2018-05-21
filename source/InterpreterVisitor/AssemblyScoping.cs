using System.Reflection;
using static AHKCore.Nodes;
using System;
using System.Linq;
using static AHKCore.IndexedNodesFragment.Variables;

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
			return method.Invoke(scope is Type? null : scope, 
				func.functionParameterList.Select(i => i.extraInfo).ToArray());
		}
	}
}