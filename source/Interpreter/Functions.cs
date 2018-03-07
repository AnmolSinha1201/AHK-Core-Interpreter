using System;
using static AHKCore.Nodes;
using static AHKCore.Query;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override functionCallClass functionCall(functionCallClass context)
		{
			var function = indexed.Functions[context.functionName][0];
			var oIndexed = indexed;
			indexed = new IndexedNode();

			foreach (var functionNode in function.functionBody)
				traverser.objectDispatcher(functionNode);
			
			indexed = oIndexed;
			return context;
		}
	}
}