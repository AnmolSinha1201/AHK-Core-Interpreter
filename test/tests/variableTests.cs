using System;

namespace test
{
	partial class TestCases
	{
		
		static bool variableAssign()
		{
			Console.Write("BASIC VARIABLE ASSIGN");
			var indexed = interpreter.Interpret("var1=123");

			if (indexed.Variables["var1"].Value.ToString() != "123")
				return false;
			return true;
		}

		static bool variableToVariableAssign()
		{
			Console.Write("VARIABLE TO VARIABLE ASSIGN");
			var indexed = interpreter.Interpret("var1=123\nvar2=456\nvar1=var2");

			if (indexed.Variables["var1"].Value.ToString() != "456")
				return false;
			return true;
		}
	}
}