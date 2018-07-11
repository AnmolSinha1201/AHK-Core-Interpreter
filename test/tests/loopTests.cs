using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult loopLoopTest1()
		{
			var retVal = TestRunner.Test("var:=1\nloop,3\nvar:=var+1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}