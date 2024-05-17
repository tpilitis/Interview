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
            var numArray = new NumArray([-2, 0, 3, -5, 2, -1]);

            var result = numArray.SumRange(left, rigth);
            result.Should().Be(expectedSum);
        }

        public static IEnumerable<object[]> GridSamples
        {
            get
            {
                yield return new object[] {new int[,]
                {
                    { 0, 1, 0, 0 },
                    { 1, 1, 1, 0 },
                    { 0, 1, 0, 0 },
                    { 1, 1, 0, 0 }
                }, 16};
                yield return new object[] {new int[,]
                {
                    {1}
                }, 4};
                yield return new object[] {new int[,]
                {
                    { 1, 0},
                }, 4};
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GridSamples), DynamicDataSourceType.Property)]
        public void Test_Calculate_Island_Perimeter(int[,] grid, int expectedPerimeter)
        {
            var service = new IslandPerimeter();

            var result = service.Calculate(grid);

            result.Should().Be(expectedPerimeter);
        }
    }
}
