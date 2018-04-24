using System;
using System.Collections.Generic;
using System.Linq;
using static AHKCore.IndexedNodesFragment.Variables;
using static AHKCore.Nodes;
using static AHKCore.Query;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override functionCallClass functionCall(functionCallClass context)
		{
			switch (context.extraInfo)
			{
				case null:
					if (indexed.Functions.Exists(context.functionName))
					{
						context.extraInfo = indexed;
						return functionCallAHK(context);
					}
					else if (assemblyMap.Method.Exists(context.functionName))
					{
						context.extraInfo = invokeAssemblyMethod(null, context);
						return context;
					}
					return null;

				case IndexedNode o:
					return functionCallAHK(context);
				
				default:
					context.extraInfo = invokeAssemblyMethod(context.extraInfo, context);
					return context;
			}
		}

		public functionCallClass functionCallAHK(functionCallClass context)
		{
			IndexedNode scope = (IndexedNode)context.extraInfo;
			var function = scope.Functions[context.functionName][0];
			scope = new IndexedNode();

			var parameterVariableAssignList = addParams(context, function);
			function.functionBody = parameterVariableAssignList.Concat(function.functionBody).ToList();

			foreach (var functionNode in function.functionBody)
			{
				var retVal = traverser.objectDispatcher(functionNode);
				if (retVal is returnBlockClass r)
				{
					context.extraInfo = r.extraInfo;
					break;
				}
			}
			
			return context;
		}

		List<variableAssignClass> addParams(functionCallClass functionCall, functionDeclarationClass function)
		{
			var noDefaultList = addNoDefaultParams(functionCall, function.functionHead.functionParameters.Where(
				o => o.expression == null && o.isVariadic == false).ToList());

			var defaultParamList = addDefaultParams(functionCall, function.functionHead.functionParameters.Where(
				o => o.expression != null).ToList());

			return noDefaultList.Concat(defaultParamList).ToList();
		}

		List<variableAssignClass> addNoDefaultParams(functionCallClass functionCall, List<parameterInfoClass> functionParams)
		{
			var noDefaultParamList = new List<variableAssignClass>();
			foreach (var functionParam in functionParams)
			{
				if (functionCall.functionParameterList.Count == 0)
					break;
				noDefaultParamList.Add(assignVariable(functionParam.variableName, functionCall.functionParameterList[0]));
				functionCall.functionParameterList.RemoveAt(0);
			}

			return noDefaultParamList;
		}

		List<variableAssignClass> addDefaultParams(functionCallClass functionCall, List<parameterInfoClass> functionParams)
		{
			var defaultParamList = new List<variableAssignClass>();

			foreach (var functionParam in functionParams)
				defaultParamList.Add(assignVariable(functionParam.variableName, functionParam.expression));

			return defaultParamList.Concat(addNoDefaultParams(functionCall, functionParams)).ToList();
		}

		variableAssignClass assignVariable(variableClass name, BaseAHKNode expression)
		{
			return new variableAssignClass(new complexVariableClass(null, new List<BaseAHKNode>() {name}), "=", expression);
		}

		public override complexFunctionCallClass complexFunctionCall(complexFunctionCallClass context)
		{
			for (int i = 0; i < context.functionParameterList.Count; i++)
				context.functionParameterList[i] = traverser.objectDispatcher(context.functionParameterList[i]);
			
			var scope = scopeChain(context.chain);

			BaseAHKNode retVal = null;
			switch (context.function)
			{
				case functionCallClass o:
					o.extraInfo = scope;
					retVal = functionCall(o);
				break;

				case dotUnwrapClass o:
					o.variableOrFunction.extraInfo = scope;
					retVal = functionCall((functionCallClass)o.variableOrFunction);
				break;
			}

			if (retVal == null)
				return null;

			// var retVal = scopeAndVariableOrFunction(context);
			context.extraInfo = retVal is VariableValue v? v.Value : retVal.extraInfo;
			return context;
		}

		public override returnBlockClass returnBlock(returnBlockClass context)
		{
			context.extraInfo = context.expression.extraInfo;
			return context;
		}
	}
}