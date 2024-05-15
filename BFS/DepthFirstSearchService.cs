
namespace Interview.Samples.BFS
{
    public class DepthFirstSearchService
    {
        public bool[] Search(int nodeToSearch, Graph graph)
        {
            bool[] visitedNodes = new bool[graph.Nodes];

            DfsSearch(nodeToSearch, visitedNodes, graph);

            return visitedNodes;
        }

        private void DfsSearch(int nodeToSearch, bool[] visitedNodes, Graph graph)
        {
            visitedNodes[nodeToSearch] = true;

            var children = graph.Links[nodeToSearch];
            foreach (var child in children)
            {
                if (visitedNodes[child])
                    continue;

                DfsSearch(child, visitedNodes, graph);
            }
        }
    }
}
