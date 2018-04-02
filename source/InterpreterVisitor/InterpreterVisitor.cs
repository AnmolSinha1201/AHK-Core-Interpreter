using System.Collections.Generic;

namespace AHKCore
{
	partial class InterpreterVisitor: AHKCore.BaseVisitor
	{
		//indexed will manage states
		public IndexedNode indexed;
		public NodeTraverser traverser;
		public InterpreterAssemblyMapping assemblyMap;
		public Dictionary<IndexedNode, bool> autoExecuted = new Dictionary<IndexedNode, bool>();
	}
}