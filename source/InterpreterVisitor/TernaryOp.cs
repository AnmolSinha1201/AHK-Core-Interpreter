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
		public override ternaryOperationClass ternaryOperation(ternaryOperationClass context)
		{
			if (isTrue(context.condition))
				context.extraInfo = traverser.objectDispatcher(context.ifTrue).extraInfo;
			else
				context.extraInfo = traverser.objectDispatcher(context.ifFalse).extraInfo;

			return context;
		}
	}
}