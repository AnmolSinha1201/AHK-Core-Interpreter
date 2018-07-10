using static AHKCore.Nodes;

namespace AHKCore
{
	partial class InterpreterNodeTraverser
	{
		public override ifElseBlockClass ifElseBlock(ifElseBlockClass context)
		{
			return visitor.ifElseBlock(context);
		}
	}
}