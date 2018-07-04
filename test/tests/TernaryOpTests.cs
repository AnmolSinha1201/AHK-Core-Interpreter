using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult ternaryOpTest1()
		{
			var retVal = TestRunner.Test("var:=1?123:456");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}