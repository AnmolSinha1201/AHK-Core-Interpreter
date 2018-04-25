using AHKCore;
using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;

namespace test
{
	public static class Test
	{
		public static void TestAll()
		{
			var _tests = typeof(TestCases)
			.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static);

			var failedList = new List<MethodInfo>();
			var passedList = new List<MethodInfo>();
			var exceptionList = new List<MethodInfo>();

			foreach (var _test in _tests)
			{
				var retVal = (TestResult)_test.Invoke(null, null);
				
				switch (retVal)
				{
					case TestResult.Passed:
						passedList.Add(_test);
					break;

					case TestResult.Failed:
						failedList.Add(_test);
					break;

					case TestResult.Exception:
						exceptionList.Add(_test);
					break;
				}
			}
			
			if (passedList.Count > 0)
			{
				Console.WriteLine($"({passedList.Count()}/{_tests.Count()}) TESTS PASSED");
			}
			if (failedList.Count > 0)
			{
				Console.WriteLine(failedList.Count + " TEST" + ((failedList.Count == 1)?"" : "S") + " FAILED :");
				failedList.ForEach(o => Console.WriteLine(o.Name));
			}
			if (exceptionList.Count > 0)
			{
				Console.WriteLine(exceptionList.Count + " TEST" + ((exceptionList.Count == 1)?"" : "S") + " EXITED (EXCEPTION) :");
				exceptionList.ForEach(o => Console.WriteLine(o.Name));
			}
		}

		public static void TestFunction(Func<TestResult> function)
		{
			Console.WriteLine(function().ToString());
		}
	}
}