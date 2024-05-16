using FluentAssertions;
using Interview.Samples.Application;

namespace Interview.Samples.Tests
{
    [TestClass]
    public class DijkstraAlgorithmTests
    {
        [TestMethod]
        public void Test()
        {
            int[,] graph
            = new int[,] {
                { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };

            var serviceUnderTest = new DijkstraAlgorithmService();
            var distances = serviceUnderTest.CalculatesShortesPath(graph, 0, 9);

            distances.Should().BeEquivalentTo(new[] { 0, 4, 12, 19, 21, 11, 9, 8, 14 });
        }
    }
}
