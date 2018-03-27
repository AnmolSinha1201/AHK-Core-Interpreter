using System.Reflection;
using AHKCore.MappingFragment;

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
				Type[_type.Name] = _type;
			}
		}
	}
}