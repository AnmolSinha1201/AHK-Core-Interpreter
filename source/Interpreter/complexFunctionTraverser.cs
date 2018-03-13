using static AHKCore.Nodes;

namespace AHKCore
{
	partial class InterpreterNodeTraverser
	{
		public override complexFunctionCallClass complexFunctionCall(complexFunctionCallClass context)
		{
			return visitor.complexFunctionCall(context);
		}
	}
}