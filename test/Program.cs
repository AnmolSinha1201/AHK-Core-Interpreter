using System;
using System.Reflection;
using System.Linq;

namespace test
{
	class Program
	{
		static void Main(string[] args)
		{
			Test.TestFunction(TestCases.assemblyIncludeTest);
			Test.TestAll();
		}
	}
}
