using System.Collections.Generic;

namespace AHKCoreInterpreter.SymbolTableHelper
{
	class Functions
	{
		Dictionary<string, object> FunctionList = new Dictionary<string, object>();

		public object this[string key]
		{
			get
			{
				if (FunctionList.ContainsKey(key))
					return FunctionList[key];
				return null;
			}
			set
			{
				FunctionList[key] = value;
			}
		}
	}
}