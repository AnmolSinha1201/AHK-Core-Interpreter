using System;

namespace test
{
	partial class TestCases
	{
		
		static bool basicFunctionCall()
		{
			Console.Write("BASIC FUNCTION CALL");
			var indexed = interpreter.Interpret("var=function()\nfunction(){return 12}");

			if (indexed.Variables["var"].Value.ToString() != "12")
				return false;
			return true;
		}

		static bool functionVariablePassing()
		{
			Console.Write("FUNCTION VARIABLE PASSING");
			var indexed = interpreter.Interpret("var=function(123)\nfunction(var2){return var2}");

			if (indexed.Variables["var"].Value.ToString() != "123")
				return false;
			return true;
		}
	}
}