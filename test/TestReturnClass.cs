namespace test
{
	public class TestReturnClass
	{
		public string testDescription;
		public bool bPassed;

		public TestReturnClass(string testDescription, bool bPassed)
		{
			this.testDescription = testDescription;
			this.bPassed = bPassed;
		}

		public TestReturnClass(string testDescription)
		{
			this.testDescription = testDescription;
		}

		public TestReturnClass AsTrue()
		{
			this.bPassed = true;
			return this;
		}

		public TestReturnClass AsFalse()
		{
			this.bPassed = false;
			return this;
		}
	}
}