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
		public override loopLoopClass loopLoop(loopLoopClass context)
		{
			Int64 loopCount = 0;
			if (context.count != null)
				loopCount = (Int64)traverser.expression(context.count).extraInfo;

			for (Int64 i = 0; i < loopCount; i++)
			{
				context.extraInfo = null;
				foreach (var node in context.loopBody)
				{
					var retVal = traverser.objectDispatcher(node);

					if (retVal.extraInfo is returnBlockClass || retVal.extraInfo is breakBlockClass 
					|| retVal.extraInfo is continueBlockClass)
					{
						context.extraInfo = retVal.extraInfo;
						break;
					}
				}

				if (context.extraInfo == null)
					continue;
				
				if (context.extraInfo is returnBlockClass)
					return context;
				if (context.extraInfo is breakBlockClass)
					break;
				if (context.extraInfo is continueBlockClass)
					continue;
			}

			return context;
		}

		public override whileLoopClass whileLoop(whileLoopClass context)
		{
			while (isTrue(traverser.objectDispatcher(context.condition)))
			{
				context.extraInfo = null;
				foreach (var node in context.loopBody)
				{
					var retVal = traverser.objectDispatcher(node);

					if (retVal.extraInfo is returnBlockClass || retVal.extraInfo is breakBlockClass 
					|| retVal.extraInfo is continueBlockClass)
					{
						context.extraInfo = retVal.extraInfo;
						break;
					}
				}

				if (context.extraInfo == null)
					continue;
				
				if (context.extraInfo is returnBlockClass)
					return context;
				if (context.extraInfo is breakBlockClass)
					break;
				if (context.extraInfo is continueBlockClass)
					continue;
			}

			return context;
		}
	}
}