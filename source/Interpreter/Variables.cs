using System;
using static AHKCore.Nodes;
using static AHKCore.Query;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override complexVariableClass complexVariable(complexVariableClass context)
		{
			context.extraInfo = context.variable.extraInfo;
			return context;
		}

		public override variableClass variable(variableClass context)
		{
			context.extraInfo = indexed.Variables[context.variableName];
			return context;
		}
		
		public override variableAssignClass variableAssign(variableAssignClass context)
		{
			indexed.Variables[context.complexVariable.variable.variableName] = context.expression.extraInfo;
			return context;
		}
	}
}