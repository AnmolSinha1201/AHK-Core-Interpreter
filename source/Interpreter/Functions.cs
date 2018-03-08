using System;
using System.Collections.Generic;
using System.Linq;
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

			var parameterVariableAssignList = new List<variableAssignClass>();
			for(int i = 0; i < context.functionParameterList.Count; i++)
			{
				parameterVariableAssignList.Add(
					new variableAssignClass(
						new complexVariableClass(null, new List<BaseAHKNode>() {function.functionHead.functionParameters[i].variableName}),
					"=", (BaseAHKNode)context.functionParameterList[i])
				);
			}

			function.functionBody = parameterVariableAssignList.Concat(function.functionBody).ToList();

			foreach (var functionNode in function.functionBody)
				traverser.objectDispatcher(functionNode);
			
			indexed = oIndexed;
			return context;
		}
	}
}