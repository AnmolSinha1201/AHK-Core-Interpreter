using System;
using static AHKCore.Nodes;
using static AHKCore.Query;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override STRINGClass STRING(STRINGClass context)
		{
			context.extraInfo = context.STRING;
			return context;
		}

		public override INTClass INT(INTClass context)
		{
			context.extraInfo = context.INT;
			return context;
		}

	}
}