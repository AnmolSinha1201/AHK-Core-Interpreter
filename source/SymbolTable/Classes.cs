using System.Collections.Generic;

namespace AHKCore.SymbolTableHelper
{
	class Classes
	{
		Dictionary<string, object> ClassList = new Dictionary<string, object>();

		public object this[string key]
		{
			get
			{
				if (ClassList.ContainsKey(key))
					return ClassList[key];
				return null;
			}
			set
			{
				ClassList[key] = value;
			}
		}
	}
}