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
		public override parenthesesExpressionClass parenthesesExpression(parenthesesExpressionClass context)
		{
			context.extraInfo = context.expression.extraInfo;
			return context;
		}
	}
}