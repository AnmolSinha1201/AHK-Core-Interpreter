using System;
using static AHKCore.Nodes;
using static AHKCore.Query;
using static AHKCore.IndexedNodesFragment.Variables;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override complexVariableClass complexVariable(complexVariableClass context)
		{
			var oIndexed = indexed;
			context = (complexVariableClass)scopeAndVariableOrFunction(context);

			indexed = oIndexed;
			return context;
		}

		public override variableClass variable(variableClass context)
		{
			context.extraInfo = indexed.Variables[context.variableName];
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