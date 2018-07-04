using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult basicNewObject()
		{
			var retVal = TestRunner.Test("var2:=new class()\nvar:=var2.var1\nclass class{var1:=123}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value?.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult basicNewObjectVariableChange()
		{
			var retVal = TestRunner.Test("var2:=new class()\nclass.var1:=456\nvar:=var2.var1\nclass class{var1:=123}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value?.ToString() != "123"
				&& retVal.indexed.Classes["class"].Variables["var1"].Value?.ToString() != "456")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}