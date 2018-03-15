namespace AHKCore
{
	partial class InterpreterNodeTraverser: AHKCore.NodeTraverser
	{
		public InterpreterNodeTraverser(BaseVisitor visitor = null)
		{
			this.visitor = visitor ?? new defaultVisitor();
		}

		class defaultVisitor: BaseVisitor {}
	}
}