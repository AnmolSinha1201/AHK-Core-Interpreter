using System.Reflection;
using AHKCore.MappingFragment;

namespace AHKCore
{
	public partial class InterpreterAssemblyMapping
	{
		public NamespaceMap Namespace = new NamespaceMap();
		public TypeMap Type = new TypeMap();

		/*
			- Map outer classes only.
		 */
		public void mapNamespace(Assembly asm)
		{
			foreach (var _type in asm.GetTypes())
			{
				if (_type.IsNested)
					continue;
				Namespace[_type.Namespace].Add(_type);
			}
		}
	}
}