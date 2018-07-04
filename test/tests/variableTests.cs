using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult variableAssign()
		{
			var retVal = TestRunner.Test("var1:=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var1"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableToVariableAssign()
		{
			var retVal = TestRunner.Test("var1:=123\nvar2:=456\nvar1:=var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var1"].Value.ToString() != "456")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classVariableAssign()
		{
			var retVal = TestRunner.Test("var:=class.var1\nclass class{var1:=123}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classVariableToVariableAssign()
		{
			var retVal = TestRunner.Test("var:=456\nclass.var1:=123\nvar:=class.var1\nclass class{}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}