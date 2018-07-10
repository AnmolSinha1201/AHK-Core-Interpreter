using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult ifElseTest1()
		{
			var retVal = TestRunner.Test("if(1)var:=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult ifElseTest2()
		{
			var retVal = TestRunner.Test("if(0)var:=456\nelse var:=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult ifElseTest3()
		{
			var retVal = TestRunner.Test("if(0)var:=456\nelse if (0)var:=789\nelse var:=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult ifElseTest4()
		{
			var retVal = TestRunner.Test("var:=func(1)\nfunc(var){if(var=1)return 456\nelse if (var=2)return 789\nelse return 123}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "456")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult ifElseTest5()
		{
			var retVal = TestRunner.Test("var:=func(2)\nfunc(var){if(var=1)return 456\nelse if (var=2)return 789\nelse return 123}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "789")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult ifElseTest6()
		{
			var retVal = TestRunner.Test("var:=func(3)\nfunc(var){if(var=1)return 456\nelse if (var=2)return 789\nelse return 123}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}