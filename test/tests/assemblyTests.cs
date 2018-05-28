using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult assemblyIncludeTest()
		{
			var retVal = TestRunner.Test("#include, Stub.dll\nvar=Functions.Test2(123)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult assemblyIncludeUsingTest()
		{
			var retVal = TestRunner.Test("#include, Stub.dll\n#using Functions\nvar=Test2(123)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult assemblyIncludeUsingTest2()
		{
			var retVal = TestRunner.Test("#include, Stub.dll\n#using Functions\nvar=Functions.Test2(123)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult assemblyInstanceFunctionCall()
		{
			var retVal = TestRunner.Test("#include, Stub.dll\n#using Functions\nvar=Test3(123)\nvar2=var.GetText()");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var2"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult assemblyIncludeNoUsing()
		{
			var retVal = TestRunner.Test("#include, Stub.dll\n\nvar=Test3(123)\nvar2=var.GetText()");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var2"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}
		
		public static TestResult assemblyPassingVariable()
		{
			var retVal = TestRunner.Test("#include, Stub.dll\nvar1=123\nvar=Test2(var1)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult assemblyRefMethodPassingVariable()
		{
			var retVal = TestRunner.Test("#include, Stub.dll\nvar=456\nTest4(var)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult assemblyRefMethodPassingUnassignedVariable()
		{
			var retVal = TestRunner.Test("#include, Stub.dll\nTest4(var)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}