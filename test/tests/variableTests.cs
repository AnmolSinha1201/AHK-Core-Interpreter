using System;

namespace test
{
	partial class TestCases
	{
		
		public static TestReturnClass variableAssign()
		{
			var retVal = new TestReturnClass("basic variable assign");
			var indexed = interpreter.Interpret("var1=123");

			if (indexed.Variables["var1"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		public static TestReturnClass variableToVariableAssign()
		{
			var retVal = new TestReturnClass("variable to variable assign");
			var indexed = interpreter.Interpret("var1=123\nvar2=456\nvar1=var2");

			if (indexed.Variables["var1"].Value.ToString() != "456")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		public static TestReturnClass classVariableAssign()
		{
			var retVal = new TestReturnClass("class variable assign");
			var indexed = interpreter.Interpret("var=class.var1\nclass class{var1=123}");

			if (indexed.Variables["var"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		public static TestReturnClass classVariableToVariableAssign()
		{
			var retVal = new TestReturnClass("class variable to variable assign");
			var indexed = interpreter.Interpret("var=456\nclass.var1=123\nvar=class.var1\nclass class{}");

			if (indexed.Variables["var"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}
	}
}