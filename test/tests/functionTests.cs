using System;

namespace test
{
	partial class TestCases
	{
		
		static TestReturnClass basicFunctionCall()
		{
			var retVal = new TestReturnClass("basic function call");
			var indexed = interpreter.Interpret("var=function()\nfunction(){return 12}");

			if (indexed.Variables["var"].Value.ToString() != "12")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		static TestReturnClass functionVariablePassing()
		{
			var retVal = new TestReturnClass("function variable passing (no default value)");
			var indexed = interpreter.Interpret("var=function(123)\nfunction(var2){return var2}");

			if (indexed.Variables["var"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		static TestReturnClass functionVariablePassing2()
		{
			var retVal = new TestReturnClass("function variable passing (default value)");
			var indexed = interpreter.Interpret("var=function(123)\nfunction(var2=456){return var2}");

			if (indexed.Variables["var"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		static TestReturnClass functionVariablePassing3()
		{
			var retVal = new TestReturnClass("function variable passing (default value, no value passed)");
			var indexed = interpreter.Interpret("var=function()\nfunction(var2=456){return var2}");

			if (indexed.Variables["var"].Value.ToString() != "456")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}
	}
}