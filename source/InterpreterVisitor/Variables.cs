using System;
using static AHKCore.Nodes;
using static AHKCore.Query;
using static AHKCore.IndexedNodesFragment.Variables;

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
			var scope = scopeChain(context.chain);
			
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
			switch (context.expression.extraInfo)
			{
				case VariableValue o:
					((VariableValue)context.complexVariable.extraInfo).Value = o.Value;
				break;

				default:
					((VariableValue)context.complexVariable.extraInfo).Value = context.expression.extraInfo;
				break;
			}
			return context;
		}
	}
}