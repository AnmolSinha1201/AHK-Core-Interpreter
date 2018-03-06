using System;
using static AHKCore.Nodes;
using static AHKCore.Query;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override BaseAHKNode expression(BaseAHKNode context)
		{
			return context;
		}
	}
}