using System;
using static AHKCore.Nodes;
using static AHKCore.Query;
using static AHKCore.IndexedNodesFragment.Variables;
using System.Collections.Generic;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		public override newObjectClass newObject(newObjectClass context)
		{
			List<BaseAHKNode> parameterList = null;
			switch (context.className)
			{
				case functionCallClass o:
					parameterList = o.functionParameterList;
				break;

				case dotUnwrapClass o:
					parameterList = ((functionCallClass)o.variableOrFunction).functionParameterList;
				break;
			}
			for (int i = 0; i < parameterList.Count; i++)
				parameterList[i] = traverser.objectDispatcher(parameterList[i]);
			
			var scope = scopeChain(context.chain);

			BaseAHKNode retVal = null;
			switch (context.className)
			{
				case functionCallClass o:
					o.extraInfo = scope;
					retVal = createNewInstance(o);
				break;

				case dotUnwrapClass o:
					o.variableOrFunction.extraInfo = scope;
					retVal = createNewInstance((functionCallClass)o.variableOrFunction);
				break;
			}

			if (retVal == null)
				return null;

			// var retVal = scopeAndVariableOrFunction(context);
			context.extraInfo = retVal is VariableValue v? v.Value : retVal.extraInfo;
			return context;
		}

		functionCallClass createNewInstance(functionCallClass context)
		{
			switch (context.extraInfo)
			{
				case null:
					if (indexed.Classes.Exists(context.functionName))
					{
						context.extraInfo = indexed;
						return createNewInstanceAHK(context);
					}
					else if (assemblyMap.Type.Exists(context.functionName))
					{
						// context.extraInfo = invokeAssemblyMethod(null, context);
						// return context;
					}
					return null;

				case IndexedNode o:
					return createNewInstanceAHK(context);
				
				default:
					// context.extraInfo = invokeAssemblyMethod(context.extraInfo, context);
					return context;
			}
		}

		functionCallClass createNewInstanceAHK(functionCallClass context)
		{
			var baseClass = ((IndexedNode)context.extraInfo).Classes[context.functionName];
			var newScope = new IndexedNode();

			newScope.Functions = baseClass.Functions;
			newScope.Classes = baseClass.Classes;
			newScope.AutoExecute = baseClass.AutoExecute;

			autoExec(newScope);
			autoExecuted[newScope] = true;

			context.extraInfo = newScope;
			return context;
		}
		
		void autoExec(IndexedNode ind)
		{
			var oIndex = indexed;
			indexed = ind;

			foreach (var node in ind.AutoExecute)
				traverser.objectDispatcher(node);
			
			indexed = oIndex;
		}
	}
}