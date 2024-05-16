using FluentAssertions;
using Interview.Samples.Application;

namespace Interview.Samples.Tests
{
    [TestClass]
    public class FindSafenessPathInGridTests
    {
        [TestMethod]
        public void Test()
        {
            int[,] grid = new int[,]
            {
                { 0, 0, 0, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 1, 0, 0, 0 },
            };

            var safestFactor = FindSafenessPathInGrid.FindMaximumSafenessFactor(grid);

            safestFactor.Should().Be(2);
        }
    }
}
