using System;

namespace test
{
	partial class TestCases
	{
		public static TestResult binaryOpMathematicalTest1()
		{
			var retVal = TestRunner.Test("var:=1+2+3*4-5-6");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpMathematicalTest2()
		{
			var retVal = TestRunner.Test("var:=1*(2+3)*4");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "20")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpMathematicalTest3()
		{
			var retVal = TestRunner.Test("var:=3**(5//2)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "9")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpConcatTest1()
		{
			var retVal = TestRunner.Test("var:=3 . 2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "32")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpConcatTest2()
		{
			var retVal = TestRunner.Test("var1:=\"text\"\nvar:=var1 . 2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "text2")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpConcatTest3()
		{
			var retVal = TestRunner.Test("var1:=\"text\"\nvar2:=\"text2\"\nvar:=var1 . var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "texttext2")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest1()
		{
			var retVal = TestRunner.Test("var:=1=1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest2()
		{
			var retVal = TestRunner.Test("var1:=\"QWE\"\nvar2:=\"qwe\"\nvar:=var1=var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest3()
		{
			var retVal = TestRunner.Test("var1:=\"asd\"\nvar2:=\"qwe\"\nvar:=var1=var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest4()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest5()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1<123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest6()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1>122");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest7()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1>=124");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest8()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1>=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest9()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1<=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest10()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1<=124");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest11()
		{
			var retVal = TestRunner.Test("var:=1==1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest12()
		{
			var retVal = TestRunner.Test("var1:=\"QWE\"\nvar2:=\"qwe\"\nvar:=var1==var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest13()
		{
			var retVal = TestRunner.Test("var1:=\"asd\"\nvar2:=\"qwe\"\nvar:=var1==var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest14()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1==123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest15()
		{
			var retVal = TestRunner.Test("var1:=122\nvar:=var1!=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest16()
		{
			var retVal = TestRunner.Test("var1:=123\nvar:=var1!=123");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest17()
		{
			var retVal = TestRunner.Test("var:=1&&2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest18()
		{
			var retVal = TestRunner.Test("var:=1&&0");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "False")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest19()
		{
			var retVal = TestRunner.Test("var:=1&&0=0");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest20()
		{
			var retVal = TestRunner.Test("var1:=123\nvar2:=\"text2\"\nvar:=var1&&var2");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest21()
		{
			var retVal = TestRunner.Test("var1:=123\nvar2:=\"text2\"\nvar:=1=(var1&&var2)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "True")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpLogicalTest22()
		{
			var retVal = TestRunner.Test("var1:=123\nvar2:=\"text2\"\nvar:=1+(var1&&var2)");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "2")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpBitwiseTest1()
		{
			var retVal = TestRunner.Test("var:=1<<1+1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpBitwiseTest2()
		{
			var retVal = TestRunner.Test("var:=1<<1+(1&&\"text\")");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpBitwiseTest3()
		{
			var retVal = TestRunner.Test("var:=5&1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "1")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpBitwiseTest4()
		{
			var retVal = TestRunner.Test("var:=4|1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "5")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpBitwiseTest5()
		{
			var retVal = TestRunner.Test("var:=5|1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "5")
				return TestResult.Failed;
			return TestResult.Passed;
		}

		public static TestResult binaryOpBitwiseTest6()
		{
			var retVal = TestRunner.Test("var:=5^1");
			if (retVal.result == TestResult.Exception)
				return TestResult.Exception;
			
			if (retVal.indexed.Variables["var"].Value.ToString() != "4")
				return TestResult.Failed;
			return TestResult.Passed;
		}
	}
}