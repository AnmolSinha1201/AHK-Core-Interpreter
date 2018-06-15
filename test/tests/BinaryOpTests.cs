using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult binaryOpTest1()
		{
			var retVal = TestRunner.Test("var=1+2+3*4-5-6");
			// var retVal = TestRunner.Test("var=1*(2+3)*4");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}