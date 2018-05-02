using static AHKCore.Nodes;

namespace AHKCore
{
	partial class InterpreterNodeTraverser
	{
		public override newObjectClass newObject(newObjectClass context)
		{
			return visitor.newObject(context);
		}
	}
}