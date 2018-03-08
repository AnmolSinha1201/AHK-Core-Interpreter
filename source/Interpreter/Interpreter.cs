using System.Collections.Generic;
using System;

namespace AHKCore
{
	class Interpreter
	{
		public void Interpret()
		{
			var parserInstance = new Parser();
			var AHKNodes = parserInstance.parse("asd(123)\nasd(var99){var1=123\nvar2=456\nvar1=var2}");
			
			var indexer = new NodeIndexer();
			var indexedNodes = indexer.IndexNodes(AHKNodes);
			
			var visitor = new InterpreterVisitor();
			var traverser = new AHKCore.NodeTraverser(visitor);

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
}