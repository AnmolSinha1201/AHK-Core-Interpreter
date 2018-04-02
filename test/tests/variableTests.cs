using System;

namespace test
{
	partial class TestCases
	{
		
		static TestReturnClass variableAssign()
		{
			var retVal = new TestReturnClass("basic variable assign");
			var indexed = interpreter.Interpret("var1=123");

			if (indexed.Variables["var1"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		static TestReturnClass variableToVariableAssign()
		{
			var retVal = new TestReturnClass("variable to variable assign");
			var indexed = interpreter.Interpret("var1=123\nvar2=456\nvar1=var2");

			if (indexed.Variables["var1"].Value.ToString() != "456")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}
	}
}