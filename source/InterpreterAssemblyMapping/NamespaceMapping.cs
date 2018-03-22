using System.Reflection;
using System.Collections.Generic;
using System;

namespace AHKCore.MappingFragment
{
	public class NamespaceMap
	{
		Dictionary<string, List<Type>> namespaceMapping  = new Dictionary<string, List<Type>>();

		public List<Type> this[string name]
		{
			get
			{
				if (!namespaceMapping.ContainsKey(name.ToLower()))
					namespaceMapping.Add(name.ToLower(), new List<Type>());
				return namespaceMapping[name.ToLower()];
			}
		}

		public bool Exists(string name)
		{
			return namespaceMapping.ContainsKey(name.ToLower());
		}
	}
}