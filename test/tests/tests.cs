using AHKCore;
using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;

namespace test
{
	public static partial class TestCases
	{
		static Interpreter interpreter = new Interpreter();
	}

	public static class Test
	{
		public static void TestAll()
		{
			var _tests = typeof(TestCases)
			.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static);

			var failedList = new List<TestReturnClass>();
			foreach (var _test in _tests)
			{
				var retVal = (TestReturnClass)_test.Invoke(null, null);
				if (!retVal.bPassed)
					failedList.Add(retVal);
			}

			if (failedList.Count > 0)
			{
				Console.WriteLine(failedList.Count + " TEST" + ((failedList.Count == 1)?"" : "S") + " FAILED :");
				failedList.ForEach(o => Console.WriteLine(o.testDescription));
			}
			else
			{
				Console.WriteLine($"({_tests.Count()}/{_tests.Count()}) TESTS PASSED");
			}

		}
	}
}