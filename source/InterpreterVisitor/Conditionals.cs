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
		bool isTrue(BaseAHKNode node)
		{
			switch (node)
			{
				case INTClass o:
					return o.INT != 0;
				
				case DOUBLEClass o:
					return true;
				
				case HEXClass o:
					return true;

				case complexVariableClass o:
					if (o.extraInfo is VariableValue v)
						return isTrue(v.Value);
				return false;

				case binaryOperationClass o:
					return isTrue(o.extraInfo);

				default:
					return isTrue(node.extraInfo);
			}
		}

		bool isTrue(object item)
		{
			if (item == null)
				return false;

			if (item is bool)
				return (bool)item;

			if (item.ToString() != "0")
				return true;
				
			return false;
		}
	}
}