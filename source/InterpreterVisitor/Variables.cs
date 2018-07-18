using System;
using static AHKCore.Nodes;
using static AHKCore.Query;
using static AHKCore.IndexedNodesFragment.Variables;
using System.Collections.Generic;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override variableClass variable(variableClass context)
		{
			switch (context.extraInfo)
			{
				case IndexedNode o:
					return variableGetAHK(context);

				case null:
					context.extraInfo = indexed;
					return variableGetAHK(context);
			}

			return null;
		}

		public variableClass variableGetAHK(variableClass context)
		{
			var scope = (IndexedNode)context.extraInfo;

			context.extraInfo = scope.Variables[context.variableName];
			return context;
		}

		public override complexVariableClass complexVariable(complexVariableClass context)
		{
			var scope = scopeChain(context.chain, context._this == null? indexed : indexed.Parent);
			if (context._this != null && scope == null && indexed.Parent != null)
				scope = indexed.Parent;
			
			BaseAHKNode retVal = null;
			switch(context.variable)
			{
				case variableClass o:
					o.extraInfo = scope;
					retVal = variable(o);
				break;

				case dotUnwrapClass o:
					o.variableOrFunction.extraInfo = scope;
					retVal = variable((variableClass)o.variableOrFunction);
				break;
			}

			if (retVal == null)
				return null;

			context.extraInfo = retVal.extraInfo;
			return context;
		}
		
		public override variableAssignClass variableAssign(variableAssignClass context)
		{
			var contextEI = context.expression.extraInfo is VariableValue v?
				v.Value : context.expression.extraInfo;

			switch (context.op)
			{
				case "=":
				case ":=":
					((VariableValue)context.complexVariable.extraInfo).Value = contextEI;
				break;

				default:
					var exp = new binaryOperationClass(new List<BaseAHKNode>() 
						{context.complexVariable, new opClass(context.op.Substring(0, context.op.Length - 1)), context.expression});
					((VariableValue)context.complexVariable.extraInfo).Value = traverser.binaryOperation(exp).extraInfo;
				break;
			}
			
			return context;
		}
	}
}