using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult variableAssign()
		{
			var retVal = TestRunner.Test("var1:=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var1"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableToVariableAssign()
		{
			var retVal = TestRunner.Test("var1:=123\nvar2:=456\nvar1:=var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var1"].Value.ToString() != "456")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classVariableAssign()
		{
			var retVal = TestRunner.Test("var:=class.var1\nclass class{var1:=123}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult classVariableToVariableAssign()
		{
			var retVal = TestRunner.Test("var:=456\nclass.var1:=123\nvar:=class.var1\nclass class{}");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest1()
		{
			var retVal = TestRunner.Test("var:=122\nvar+=1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest2()
		{
			var retVal = TestRunner.Test("var:=124\nvar-=1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "123")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest3()
		{
			var retVal = TestRunner.Test("var:=11\nvar*=11");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "121")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest4()
		{
			var retVal = TestRunner.Test("var:=121\nvar/=5");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "24.2")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest5()
		{
			var retVal = TestRunner.Test("var:=121\nvar//=5");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "24")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest6()
		{
			var retVal = TestRunner.Test("var:=123\nvar.=5");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "1235")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest7()
		{
			var retVal = TestRunner.Test("var:=4\nvar|=1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "5")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest8()
		{
			var retVal = TestRunner.Test("var:=5\nvar&=1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "1")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest9()
		{
			var retVal = TestRunner.Test("var:=5\nvar^=1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest10()
		{
			var retVal = TestRunner.Test("var:=1\nvar<<=2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult variableAssignTest11()
		{
			var retVal = TestRunner.Test("var:=4\nvar>>=1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "2")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}