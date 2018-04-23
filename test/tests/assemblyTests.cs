using System;

namespace test
{
	partial class TestCases
	{
		public static TestReturnClass assemblyIncludeTest()
		{
			var retVal = new TestReturnClass("assembly include");
			var indexed = interpreter.Interpret("#include, Stub.dll\nvar=Functions.Test2(123)");

			if (indexed.Variables["var"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		public static TestReturnClass assemblyIncludeUsingTest()
		{
			var retVal = new TestReturnClass("assembly include");
			var indexed = interpreter.Interpret("#include, Stub.dll\n#using Functions\nvar=Test2(123)");

			if (indexed.Variables["var"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		public static TestReturnClass assemblyIncludeUsingTest2()
		{
			var retVal = new TestReturnClass("assembly include");
			var indexed = interpreter.Interpret("#include, Stub.dll\n#using Functions\nvar=Functions.Test2(123)");

			if (indexed.Variables["var"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}

		public static TestReturnClass assemblyInstanceFunctionCall()
		{
			var retVal = new TestReturnClass("assembly instance function call");
			var indexed = interpreter.Interpret("#include, Stub.dll\n#using Functions\nvar=Test3(123)\nvar2=var.GetText()");

			if (indexed.Variables["var2"].Value.ToString() != "123")
				return retVal.AsFalse();
			return retVal.AsTrue();
		}
	}
}