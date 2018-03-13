using static AHKCore.Nodes;

namespace AHKCore
{
	partial class InterpreterNodeTraverser
	{
		public override complexVariableClass complexVariable(complexVariableClass context)
		{
			return visitor.complexVariable(context);
		}
	}
}