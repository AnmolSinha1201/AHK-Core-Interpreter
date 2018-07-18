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
			var function = getCorrectFunctionOverload(scope.Functions[context.functionName], context);
			if (function == null){} //incorrect overload error

			foreach (var exp in context.functionParameterList)
				traverser.objectDispatcher(exp);
			
			// var parameterVariableAssignList = addParams(context, function);
			// function.functionBody = parameterVariableAssignList.Concat(function.functionBody).ToList();

			var oIndexed = indexed;
			indexed = new IndexedNode();
			indexed.Functions = oIndexed.Functions;
			indexed.Classes = oIndexed.Classes;
			indexed.Parent = scope;

			setParameters(context, function);

			foreach (var functionNode in function.functionBody)
			{
				var retVal = traverser.objectDispatcher(functionNode);
				if (retVal.extraInfo is returnBlockClass r)
				{
					context.extraInfo = r.expression?.extraInfo;
					break;
				}
			}

			indexed = oIndexed;			
			return context;
		}

		functionDeclarationClass getCorrectFunctionOverload(List<functionDeclarationClass> functionList, functionCallClass functionCall)
		{			
			var retList = new List<functionDeclarationClass>();
			var callParamCount = functionCall.functionParameterList.Count;

			foreach (var function in functionList)
			{
				var requiredParams = function.functionHead.functionParameters.Where(i => !i.isVariadic && i.expression == null).Count();
				var totalParams = function.functionHead.functionParameters.Count;

				if (callParamCount == requiredParams)
					retList.Add(function);
				else if (callParamCount > requiredParams && callParamCount <= totalParams)
					retList.Add(function);
			}

			return retList.OrderBy(i => i.functionHead.functionParameters.Count).FirstOrDefault();
		}

		void setParameters(functionCallClass functionCall, functionDeclarationClass function)
		{
			if (function.functionHead.functionParameters.Count == 0)
				return;

			if (function.functionHead.functionParameters.Count < functionCall.functionParameterList.Count
			&& !function.functionHead.functionParameters.Last().isVariadic)
			{ return; } //error: signature mismatch

			// no default parameters or overriden default parameters
			for (int i = 0; i < functionCall.functionParameterList.Count; i++)
			{
				var _variable = variable(function.functionHead.functionParameters[i].variableName);
				var exp = functionCall.functionParameterList[i].extraInfo;
				exp = exp is VariableValue? ((VariableValue)exp).Value : exp;

				((VariableValue)_variable.extraInfo).Value = exp;
			}

			// default parameters
			for (int i = functionCall.functionParameterList.Count; i < function.functionHead.functionParameters.Count; i++)
			{
				var _variable = variable(function.functionHead.functionParameters[i].variableName);
				var exp = traverser.objectDispatcher(function.functionHead.functionParameters[i].expression).extraInfo;
				exp = exp is VariableValue? ((VariableValue)exp).Value : exp;

				((VariableValue)_variable.extraInfo).Value = exp;
			}
		}

		public override complexFunctionCallClass complexFunctionCall(complexFunctionCallClass context)
		{
			var scope = scopeChain(context.chain, context._this == null? indexed : indexed.Parent);
			// in case of this.function() in a class method
			if (context._this != null && scope == null && indexed.Parent != null)
				scope = indexed.Parent;

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

			// context.extraInfo = retVal is VariableValue v? v.Value : retVal.extraInfo;
			context.extraInfo = retVal.extraInfo;
			return context;
		}

		public override returnBlockClass returnBlock(returnBlockClass context)
		{
			context.extraInfo = context;
			return context;
		}
	}
}