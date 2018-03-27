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
			if (context.expression is complexVariableClass c) //used for variable to variable assigns
			{
				Console.WriteLine(((variableClass)context.complexVariable.variable).variableName + "=" +((VariableValue)c.variable.extraInfo).Value);
				((VariableValue)context.complexVariable.variable.extraInfo).Value = ((VariableValue)c.variable.extraInfo).Value;
			}
			else
			{
				Console.WriteLine(((variableClass)context.complexVariable.variable).variableName + "=" + context.expression.extraInfo);
				((VariableValue)context.complexVariable.variable.extraInfo).Value = context.expression.extraInfo;
			}
			return context;
		}
	}
}