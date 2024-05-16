using FluentAssertions;
using Interview.Samples.Application.Arrays;

namespace Interview.Samples.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [DataTestMethod]
        [DataRow(0, 2, 1)]
        [DataRow(2, 5, -1)]
        [DataRow(0, 5, -3)]
        public void Test_RangeSum_Immutable(int left, int rigth, int expectedSum)
        {
            var numArray = new NumArray([-2, 0, 3, - 5, 2, -1]);
            
            var result = numArray.SumRange(left, rigth);
            result.Should().Be(expectedSum);
        }
    }
}
