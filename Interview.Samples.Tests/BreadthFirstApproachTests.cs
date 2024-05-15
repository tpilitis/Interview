using FluentAssertions;
using Interview.Samples.BFS;

namespace Interview.Samples.Tests
{
    [TestClass]
    public class BreadthFirstApproachTests
    {
        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void BFS_Graph_Using_AdjacencyList_Traverse_ExpectOutput()
        {
            const int nodes = 5;
            const int startNode = 0;

            var graph = new Graph(nodes);
            graph.AddLink(0, 1);
            graph.AddLink(0, 2);
            graph.AddLink(1, 2);
            graph.AddLink(1, 3);
            graph.AddLink(2, 1);
            graph.AddLink(2, 4);
            graph.AddLink(3, 4);

            var result = graph.BreathFirstSearch(startNode);

            result.Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 4 });
        }

        [TestMethod]
        public void BFS_Find_Level_OfNode()
        {
            const int startNode = 0;
            int[,] edges = new int[,]
            {
                { 0, 1 },
                { 0, 2 },
                { 1, 3 },
                { 2, 4 }
            };
            var graph = new Graph(edges);

            var level = graph.FindNodeLevel(startNode, 3);

            level.Should().Be(2);
        }

        [TestMethod]
        public void DFS_Search_Traverse_ExpectOutput()
        {
            var graph = new Graph(4);

            graph.AddLink(0, 1);
            graph.AddLink(0, 2);
            graph.AddLink(1, 2);
            graph.AddLink(2, 0);
            graph.AddLink(2, 3);
            graph.AddLink(3, 3);

            var dfsService = new DepthFirstSearchService();
            var output = dfsService.Search(2, graph);

            var expected = new bool[graph.Nodes];
            var expectedNodes = new int[] { 2, 0, 1, 3 };
            for (int i = 0; i < expectedNodes.Length; i++)
            {
                expected[i] = true;
            }
            output.Should().BeEquivalentTo(expected);
        }
    }
}