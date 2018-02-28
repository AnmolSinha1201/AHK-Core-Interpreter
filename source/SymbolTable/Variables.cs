using System.Collections.Generic;

namespace AHKCore.SymbolTableHelper
{
	class Variables
	{
		Dictionary<string, object> VariableList = new Dictionary<string, object>();

		public object this[string key]
		{
			get
			{
				if (VariableList.ContainsKey(key))
					return VariableList[key];
				return null;
			}
			set
			{
				VariableList[key] = value;
			}
		}
	}
}