using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult basicFunctionCall()
		{
			var retVal = TestRunner.Test("var:=function()\nfunction(){return 12}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "12")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult functionVariablePassing()
		{
			var retVal = TestRunner.Test("var:=function(123)\nfunction(var2){return var2}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult functionVariablePassing2()
		{
			var retVal = TestRunner.Test("var:=function(123)\nfunction(var2=456){return var2}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult functionVariablePassing3()
		{
			var retVal = TestRunner.Test("var:=function()\nfunction(var2=456){return var2}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "456")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult functionVariablePassing4()
		{
			var retVal = TestRunner.Test("var:=123\nvar:=function(var)\nfunction(var2=456){return var2}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classFunctionCall()
		{
			var retVal = TestRunner.Test("var:=class.function()\nclass class{function(){return 123}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classFunctionCall2()
		{
			var retVal = TestRunner.Test("var:=class.function(123)\nclass class{function(var1){return var1}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classFunctionCall3()
		{
			var retVal = TestRunner.Test("var:=class.function(123)\nclass class{function(var1=456){return var1}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classFunctionCall4()
		{
			var retVal = TestRunner.Test("var:=123\nvar=class.function(var)\nclass class{function(var1=456){return var1}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classFunctionCall5()
		{
			var retVal = TestRunner.Test("var:=class.function()\nclass class{function(var1=123){return var1}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult functionOverloadingTest1()
		{
			var retVal = TestRunner.Test("var:=function()\nvar:=function(var)\nfunction(){return 122}\nfunction(var1){return var1+1}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult multipleFunctionsTest1()
		{
			var retVal = TestRunner.Test("var:=function()\nfunction(){return function(122)}\nfunction(var1){return var1+1}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult multipleFunctionsTest2()
		{
			var retVal = TestRunner.Test("var:=class.function()\nclass class{function(){return function(122)}}\nfunction(var1){return var1+1}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult multipleFunctionsTest3()
		{
			var retVal = TestRunner.Test("var:=class.function()\nclass class{function(){return this.function(122)}\nfunction(var1){return var1+1}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}
		
		public static TestResult classFunctionCall6()
		{
			var retVal = TestRunner.Test("var:=class.function()\nclass class{var:=123\nfunction(){return this.var}}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}