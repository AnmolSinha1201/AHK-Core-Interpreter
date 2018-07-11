using static AHKCore.Nodes;

namespace AHKCore
{
	partial class InterpreterNodeTraverser
	{
		public override loopLoopClass loopLoop(loopLoopClass context)
		{
			return visitor.loopLoop(context);
		}
	}
}