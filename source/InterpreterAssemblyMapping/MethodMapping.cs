using System.Reflection;
using System.Collections.Generic;
using System;

namespace AHKCore.MappingFragment
{
	public class MethodMap
	{
		Dictionary<string, List<MethodInfo>> methodMapping  = new Dictionary<string, List<MethodInfo>>();

		public List<MethodInfo> this[string name]
		{
			get
			{
				if (!methodMapping.ContainsKey(name.ToLower()))
					methodMapping.Add(name.ToLower(), new List<MethodInfo>());
				return methodMapping[name.ToLower()];
			}
		}

		public bool Exists(string name)
		{
			return methodMapping.ContainsKey(name.ToLower());
		}
	}
}