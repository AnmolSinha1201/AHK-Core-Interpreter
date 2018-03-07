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
			if (context.complexVariable.variable.GetType() == typeof(variableClass))
			{
				// Console.WriteLine(((variableClass)context.complexVariable.variable).variableName + "=" + context.expression.extraInfo);
				indexed.Variables[((variableClass)context.complexVariable.variable).variableName] = context.expression.extraInfo;
			}
			else //only for bracketUnwrap
			{
				// Console.WriteLine(context.complexVariable.variable.extraInfo + "=" + context.expression.extraInfo);
				indexed.Variables[context.complexVariable.variable.extraInfo.ToString()] = context.expression.extraInfo;
			}
			return context;
		}
	}
}