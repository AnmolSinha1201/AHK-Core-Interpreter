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
		public override binaryOperationClass binaryOperation(binaryOperationClass context)
		{
			var postfixList = ToPostfix(context.binaryOperationList);
			context.extraInfo = PostfixEvaluator(postfixList);
			
			return context;
		}

		static List<string> opPriority = new List<string>() {"=", "-", "+", "*", "/"};
		List<BaseAHKNode> ToPostfix(List<BaseAHKNode> nodes)
		{
			var stack = new Stack<opClass>();
			var retList = new List<BaseAHKNode>();

			foreach (var node in nodes)
			{
				switch (node)
				{
					case opClass o:
						while(stack.Count > 0 && opPriority.IndexOf(o.op) <= opPriority.IndexOf(stack.Peek().op))
							retList.Add(stack.Pop());
						stack.Push(o);
					break;

					case parenthesesExpressionClass o:
						retList.Add(o.expression);
					break;

					default: //basic expression
						retList.Add(node);
					break;
				}
			}

			while(stack.Count > 0)
				retList.Add(stack.Pop());

			return retList;
		}

		class dummyClass : BaseAHKNode { }
		object PostfixEvaluator(List<BaseAHKNode> postfixList)
		{
			var stack = new Stack<BaseAHKNode>();

			foreach (var node in postfixList)
			{
				switch(node)
				{
					case opClass o:
						if (stack.Count < 2) {} //error
						var item2 = stack.Pop();
						var item1 = stack.Pop();
						var retItem = new dummyClass() 
						{extraInfo = binaryOpEvaluator(item1, item2, o)};
						
						stack.Push(retItem);
					break;

					default:
						stack.Push(node);
					break;
				}
			}

			if (stack.Count != 1) {} //error
			return stack.Pop().extraInfo;
		}

		object binaryOpEvaluator(BaseAHKNode item1, BaseAHKNode item2, opClass op)
		{

			switch (op.op)
			{
				case "+":
					return (dynamic)item1.extraInfo + (dynamic)item2.extraInfo;

				case "-":
					return (dynamic)item1.extraInfo - (dynamic)item2.extraInfo;

				case "*":
					return (dynamic)item1.extraInfo * (dynamic)item2.extraInfo;

				case "/":
					return (dynamic)item1.extraInfo / (dynamic)item2.extraInfo;

				case "=":
					var item1EI = item1.extraInfo is VariableValue v1? v1.Value : item1.extraInfo;
					var item2EI = item2.extraInfo is VariableValue v2? v2.Value : item2.extraInfo;

					return item1EI.ToString().ToLower() == item2EI.ToString().ToLower();
			}

			return null;
		}
	}
}