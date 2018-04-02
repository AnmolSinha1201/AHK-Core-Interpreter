using static AHKCore.Nodes;

namespace AHKCore
{
	partial class InterpreterNodeTraverser
	{
		public override complexVariableClass complexVariable(complexVariableClass context)
		{
			return visitor.complexVariable(context);
		}

		public override variableAssignClass variableAssign(variableAssignClass context)
		{
			context.complexVariable = complexVariable(context.complexVariable);

			if (context.expression.extraInfo == null)
				context.expression = expression(context.expression);

			return visitor.variableAssign(context);
		}
	}
}