using System;
using AHKCore;

namespace test
{
	partial class TestRunner
	{
		static Interpreter interpreter = new Interpreter();

		public static TestRunnerResult Test(string testString)
		{
			var retVal = new TestRunnerResult();

			try
			{
				var indexed = interpreter.Interpret(testString);
				retVal.indexed = indexed;
			}
			catch (Exception e)
			{ retVal.result = TestResult.Exception;	}

			return retVal;
		}
	}

	public class TestRunnerResult
	{
		public TestResult result;
		public IndexedNode indexed;
	}

	public enum TestResult
	{
		Passed, Failed, Exception
	}
}