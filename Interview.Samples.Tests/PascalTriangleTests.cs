using FluentAssertions;
using Interview.Samples.Application;

namespace Interview.Samples.Tests
{
    [TestClass]
    public class PascalTriangleTests
    {
        [TestMethod]
        public void AssertPascalTriangle()
        {
            const int rows = 5;
            var triangleResult = PascalTriangleService.GenerateTriangle(rows);

            triangleResult.GetLength(0).Should().Be(rows);

            triangleResult[0].Should().BeEquivalentTo([1]);
            triangleResult[1].Should().BeEquivalentTo([1,1]);
            triangleResult[2].Should().BeEquivalentTo([1,2,1]);
            triangleResult[3].Should().BeEquivalentTo([1,3,3,1]);
            triangleResult[4].Should().BeEquivalentTo([1,4,6,4,1]);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(31)]
        public void AssertConstrainRowCannotBeLessThanOne(int rows)
        {
            var triangleResult = PascalTriangleService.GenerateTriangle(rows);

            triangleResult.Should().BeEmpty();
        }
    }
}
