using System.Reflection;
using static AHKCore.Nodes;
using System;
using System.Linq;

namespace AHKCore
{
	partial class InterpreterVisitor
	{
		BaseAHKNode assemblyScope(dynamic context, int startFrom)
		{
			Type scope = null;

			if (context.chain[startFrom] is variableClass v)
			{
				if (indexed.Variables.Exists(v.variableName) && v.extraInfo is Type t)
					scope = t;
				// else chainLink is part of assembly name
				else
				{
					scope = assemblyGetScopeNullStart(context.chain[startFrom]);
				}
				
				startFrom++;
				if (scope == null)
					return null;
			}

			for (int i = startFrom; i < context.chain.Count; i++)
			{
				scope = assemblyGetScopeNotNullStart(scope, context.chain[startFrom]);
				if (scope == null)
					return null;
			}
			
			return assemblyReturn(scope, context);
		}

		/*
			- To be used at the start of a chain. Scope will be set after this.
		 */
		Type assemblyGetScopeNullStart(BaseAHKNode varOrFunc)
		{
			switch (varOrFunc)
			{
				case variableClass o:
					if (assemblyMap.Type.Exists(o.variableName))
						return assemblyMap.Type[o.variableName];
				break;
				
				/*
					- Casting to type as anything in chain is guaranteed to return a class (or null);
				 */
				case functionCallClass o:
					if (assemblyMap.Method.Exists(o.functionName))
						return (Type)assemblyMap.Method[o.functionName][0]
						.Invoke(null, o.functionParameterList.Select(i => i.extraInfo).ToArray());
				break;

				case dotUnwrapClass o:
					return assemblyGetScopeNullStart(o.variableOrFunction);
			}
			return null;
		}

		/*
			- To be used in middle of a chain.
			- Can not be a namespace, so not checking assemblyMap.Namespace
		 */
		Type assemblyGetScopeNotNullStart(Type scope, BaseAHKNode varOrFunc)
		{
			switch (varOrFunc)
			{
				/*
					- Will be null if not found
				 */
				case variableClass o:
					return scope.GetNestedTypes()
					.Where(i => i.Name.ToLower() == o.variableName.ToLower())?.First();

				case functionCallClass o:
					return (Type)invokeAssemblyMethod(scope, o);

				case dotUnwrapClass o:
					return assemblyGetScopeNotNullStart(scope, o.variableOrFunction);
			}
			return null;
		}

		BaseAHKNode assemblyReturn(Type scope, BaseAHKNode varOrFunc)
		{
			if (scope == null)
			{
				/*
					- Can only be a function
					- Since it is endpoint, it will always be BaseAHKNode
				 */
				functionCallClass funcCall = (functionCallClass)varOrFunc;
				if (assemblyMap.Method.Exists(funcCall.functionName))
					return (BaseAHKNode)assemblyMap.Method[funcCall.functionName][0]
					.Invoke(null, funcCall.functionParameterList.Select(i => i.extraInfo).ToArray());
			}
			else
			{
				switch (varOrFunc)
				{
					case variableClass o:
					return (BaseAHKNode)scope.GetField(o.variableName.ToLower()).GetValue(null);

					case functionCallClass o:
					return (BaseAHKNode)invokeAssemblyMethod(scope, o);

					case dotUnwrapClass o:
					return assemblyReturn(scope, o.variableOrFunction);

					case complexFunctionCallClass o:
					return assemblyReturn(scope, o.function);	
				}
			}
			return null;
		}

		object invokeAssemblyMethod(Type scope, functionCallClass func)
		{
			MethodInfo[] MethodArray = null;
			if (scope == null)
			{
				if (!assemblyMap.Method.Exists(func.functionName))
					return null;
				MethodArray = assemblyMap.Method[func.functionName].ToArray();
			}
			else
				MethodArray = scope.GetMethods();
			
			return	(BaseAHKNode)MethodArray.Where(i => i.Name.ToLower() == func.functionName.ToLower() 
				&& i.GetParameters().Count() == func.functionParameterList.Count)
				.First().Invoke(null, func.functionParameterList.ToArray());
		}
	}
}