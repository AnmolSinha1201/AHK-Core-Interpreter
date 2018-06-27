using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult binaryOpTest1()
		{
			var retVal = TestRunner.Test("var=1+2+3*4-5-6");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpTest2()
		{
			var retVal = TestRunner.Test("var=1*(2+3)*4");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "20")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest1()
		{
			var retVal = TestRunner.Test("var=1=1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest2()
		{
			var retVal = TestRunner.Test("var1=\"QWE\"\nvar2=\"qwe\"\nvar=var1=var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest3()
		{
			var retVal = TestRunner.Test("var1=\"asd\"\nvar2=\"qwe\"\nvar=var1=var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest4()
		{
			var retVal = TestRunner.Test("var1=123\nvar=var1=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}