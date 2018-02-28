using AHKCoreInterpreter.SymbolTableHelper;

namespace AHKCoreInterpreter
{
	class SymbolTable
	{
		public Variables Variables = new Variables();
		public Classes Classes = new Classes();
		public Functions Functions = new Functions();
	}
}