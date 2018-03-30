using AHKCore;
using System.Reflection;
using System.Linq;
using System;

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
			.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Static);

			bool bAllPassed = true;
			foreach (var _test in _tests)
			{
				var retVal = (bool)_test.Invoke(null, null);
				Console.WriteLine(retVal? " : PASSED" : " : FAILED");
				
				if (!retVal)
				{
					bAllPassed = false;
					break;
				}
			}

			if (bAllPassed)
				Console.WriteLine("ALL TESTS PASSED");
		}
	}
}