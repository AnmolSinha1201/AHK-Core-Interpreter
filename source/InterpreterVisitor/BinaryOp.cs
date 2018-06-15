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

		static List<string> opPriority = new List<string>() {"-", "+", "*", "/"};
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
						{extraInfo = binaryOpEvaluator(item1.extraInfo, item2.extraInfo, o)};
						
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

		object binaryOpEvaluator(object item1, object item2, opClass op)
		{
			item1 = ToInt64OrDouble(item1);
			item2 = ToInt64OrDouble(item2);

			switch (op.op)
			{
				case "+":
					return (dynamic)item1 + (dynamic)item2;

				case "-":
					return (dynamic)item1 - (dynamic)item2;

				case "*":
					return (dynamic)item1 * (dynamic)item2;

				case "/":
					return (dynamic)item1 / (dynamic)item2;
			}

			return null;
		}

		object ToInt64OrDouble(object item)
		{
			long l;
			if (Int64.TryParse(item.ToString(), out l))
				return l;
			
			double d;
			if (double.TryParse(item.ToString(), out d))
				return d;
			
			return null;
		}
	}
}