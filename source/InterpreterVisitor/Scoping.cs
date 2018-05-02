using static AHKCore.Nodes;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using static AHKCore.IndexedNodesFragment.Variables;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		/*
			- Returning null if chain length = 0 because there should be no scope if there 
				is no chain.
			- Check if the chainLink is a AHK node or assembly type/instance.
			- TODO : Add functions as a valid chainLink (already supporeted by parser)
		 */
		object scopeChain(List<BaseAHKNode> chain)
		{
			if (chain.Count == 0)
				return null;
			
			object scope = indexed;
			foreach (var chainLink in chain)
			{
				if (chainLink is variableClass v)
				{
					object retVal = null;

					if (scope is IndexedNode ind)
						retVal = scopeAHKVariable(ind, v);
					if (retVal == null)
						retVal = scopeAssemblyVariable(scope, v);

					if (retVal == null)
						return null;
					scope = retVal;
				}
			}

			return scope;
		}

		IndexedNode scopeAHKVariable(IndexedNode scope, variableClass v)
		{			
			if (scope.Variables.Exists(v.variableName))
			{
				variable(v);
				if (((VariableValue)v.extraInfo).Value is IndexedNode ind)
					return ind;
				return null;
				// if v.extraInfo is instance of a type, it will be resolved in scopeAssemblyVariable
			}
			else if (scope.Classes.Exists(v.variableName))
			{
				var newScope = scope.Classes[v.variableName];
				if (!autoExecuted.ContainsKey(newScope) || !autoExecuted[newScope])
				{
					autoExec(newScope);
					autoExecuted[newScope] = true;
				}
				return newScope;
			}
			return null;
		}
	}
}