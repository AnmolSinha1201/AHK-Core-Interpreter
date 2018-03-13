using System.Collections.Generic;
using System;

namespace AHKCore
{
	class Interpreter
	{
		public void Interpret()
		{
			var parserInstance = new Parser();
			var AHKNodes = parserInstance.parse("var=zxc()\nzxc(){return 1}\nzxc.qwe=123\nzxc.asd(123)\nclass zxc{asd(varA){varZ=99}}\nasd(123, 456)\nasd(varA, varB=123, varC=789){var1=123\nvar2=456\nvar1=var2}");
			
			var indexer = new NodeIndexer();
			var indexedNodes = indexer.IndexNodes(AHKNodes);
			
			var visitor = new InterpreterVisitor();
			var traverser = new AHKCore.InterpreterNodeTraverser(visitor);

			visitor.indexed = indexedNodes;
			visitor.traverser = traverser;

			// manually calling objectDispatcher which will call its visitor functions
			foreach (var o in indexedNodes.AutoExecute)
				traverser.objectDispatcher(o);
		}
	}

	partial class InterpreterVisitor: AHKCore.BaseVisitor
	{
		//indexed will manage states
		public IndexedNode indexed;
		public NodeTraverser traverser;
	}

	partial class InterpreterNodeTraverser: AHKCore.NodeTraverser
	{
		public InterpreterNodeTraverser(BaseVisitor visitor = null)
		{
			this.visitor = visitor ?? new defaultVisitor();
		}

		class defaultVisitor: BaseVisitor {}
	}
}