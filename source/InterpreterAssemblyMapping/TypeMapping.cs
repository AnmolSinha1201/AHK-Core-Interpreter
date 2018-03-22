using System.Reflection;
using System.Collections.Generic;
using System;

namespace AHKCore.MappingFragment
{
	public class TypeMap
	{
		Dictionary<string, Type> typeMapping  = new Dictionary<string, Type>();

		public Type this[string name]
		{
			get
			{
				if (!typeMapping.ContainsKey(name.ToLower()))
					return null;
				return typeMapping[name.ToLower()];
			}
			set
			{
				typeMapping.Add(name.ToLower(), value);
			}
		}

		public bool Exists(string name)
		{
			return typeMapping.ContainsKey(name.ToLower());
		}
	}
}