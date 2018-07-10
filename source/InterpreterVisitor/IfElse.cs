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
		public override ifElseBlockClass ifElseBlock(ifElseBlockClass context)
		{
			List<BaseAHKNode> toExecute = null;

			traverser.objectDispatcher(context.ifBlock.condition);
			if (isTrue(context.ifBlock.condition))
				toExecute = context.ifBlock.body;
			else if (context.elseBlock != null)
				toExecute = context.elseBlock.body;

			foreach (var node in toExecute)
			{
				var retVal = traverser.objectDispatcher(node);
				if (retVal.extraInfo is returnBlockClass r)
				{
					context.extraInfo = r;
					break;
				}
			}

			return context;
		}
	}
}