using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult unaryOpTest1()
		{
			var retVal = TestRunner.Test("var=122\n++var");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult unaryOpTest2()
		{
			var retVal = TestRunner.Test("var=124\n--var");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult unaryOpTest3()
		{
			var retVal = TestRunner.Test("var2=124\nvar=--var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult unaryOpTest4()
		{
			var retVal = TestRunner.Test("var2=-123\nvar=-var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult unaryOpTest5()
		{
			var retVal = TestRunner.Test("var2=123\nvar=!var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult unaryOpTest6()
		{
			var retVal = TestRunner.Test("var2=123\nvar=~var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "-124")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult unaryOpTest7()
		{
			var retVal = TestRunner.Test("var2=123\nvar=var2--");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123"
				&& retVal.indexed.Variables["var2"].Value.ToString() != "122")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult unaryOpTest8()
		{
			var retVal = TestRunner.Test("var2=123\nvar=var2++");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123"
				&& retVal.indexed.Variables["var2"].Value.ToString() != "124")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}