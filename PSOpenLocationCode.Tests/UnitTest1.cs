using Xunit;
using PSOpenLocationCode;

namespace PSOpenLocationCode.Tests
{
    public class BasicTests
    {
        [Fact]
        public void Test_ProjectReference_IsWorking()
        {
            // This test checks that the main project is referenced and accessible.
            Assert.Equal("Hello from main project", TestReference.Hello);
        }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Add real tests here
        }
    }
}
