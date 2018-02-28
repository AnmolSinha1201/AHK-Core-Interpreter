using AHKCore.SymbolTableHelper;

namespace AHKCore
{
	class SymbolTable
	{
		public Variables Variables = new Variables();
		public Classes Classes = new Classes();
		public Functions Functions = new Functions();
	}
}