using static AHKCore.Nodes;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using static AHKCore.IndexedNodesFragment.Variables;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override unaryOperationClass unaryOperation(unaryOperationClass context)
		{
			if (context.unaryOperationList[0] is opClass)
				return preOp(context);
			return postOp(context);
		}

		unaryOperationClass preOp(unaryOperationClass context)
		{
			var item1EI = context.unaryOperationList[1].extraInfo is VariableValue v1? v1.Value 
			: context.unaryOperationList[1].extraInfo;
			
			switch (((opClass)context.unaryOperationList[0]).op)
			{
				case "++":
					((VariableValue)context.unaryOperationList[1].extraInfo).Value 
						= (dynamic)((VariableValue)context.unaryOperationList[1].extraInfo).Value + 1;
					context.extraInfo = ((VariableValue)context.unaryOperationList[1].extraInfo).Value;
					return context;

				case "--":
					((VariableValue)context.unaryOperationList[1].extraInfo).Value 
						= (dynamic)((VariableValue)context.unaryOperationList[1].extraInfo).Value - 1;
					context.extraInfo = ((VariableValue)context.unaryOperationList[1].extraInfo).Value;
					return context;

				case "-":
					context.extraInfo = -(dynamic)item1EI;
					return context;

				case "!":
					context.extraInfo = !isTrue(context.unaryOperationList[1]);
					return context;

				case "~":
					context.extraInfo = ~(dynamic)item1EI;
					return context;
			}

			return null;
		}

		unaryOperationClass postOp(unaryOperationClass context)
		{			
			switch (((opClass)context.unaryOperationList[1]).op)
			{
				case "++":
					context.extraInfo = ((VariableValue)context.unaryOperationList[0].extraInfo).Value;
					((VariableValue)context.unaryOperationList[0].extraInfo).Value 
						= (dynamic)((VariableValue)context.unaryOperationList[0].extraInfo).Value + 1;
					return context;

				case "--":
					context.extraInfo = ((VariableValue)context.unaryOperationList[0].extraInfo).Value;
					((VariableValue)context.unaryOperationList[0].extraInfo).Value 
						= (dynamic)((VariableValue)context.unaryOperationList[0].extraInfo).Value - 1;
					return context;
			}

			return null;
		}
	}
}