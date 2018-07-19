using System.Reflection;
using AHKCore.MappingFragment;
using System;

namespace AHKCore
{
	public partial class InterpreterAssemblyMapping
	{
		public TypeMap Type = new TypeMap();

		public MethodMap Method = new MethodMap();

		/*
			- Map outer classes only.
		 */

		public void mapTypes(Assembly asm)
		{
			foreach (var _type in asm.GetTypes())
			{
				if (_type.IsNested)
					continue;
				
				if (_type.Name.ToLower() == "functions")
					continue;
				
				Type[_type.Name] = _type;
			}
		}

		public void mapMethods(Type t)
		{
			foreach (var mInfo in t.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
				Method[mInfo.Name].Add(mInfo);
		}

		public void mapNestedTypes(Type t)
		{
			foreach (var _type in t.GetNestedTypes())
				Type[_type.Name] = _type;
		}
	}
}