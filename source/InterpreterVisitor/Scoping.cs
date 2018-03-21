using static AHKCore.Nodes;
using System.Collections.Generic;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		void ScopeScript(List<BaseAHKNode> chain)
		{
			foreach(var chainLink  in chain)
			{
				if (chainLink is variableClass v)
				{
					if (indexed.Variables.Exists(v.variableName) && v.extraInfo is IndexedNode i)
						indexed = i;
					else if (indexed.Classes[v.variableName] != null)
						indexed = indexed.Classes[v.variableName];
					else {} //throw error
				}
			}
		}
	}
}