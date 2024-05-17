namespace Interview.Samples.Application
{
    public class DijkstraAlgorithmService
    {
        private const int MaxIndex = 99999999;

        /// <summary>
        /// https://www.geeksforgeeks.org/dijkstras-shortest-path-algorithm-greedy-algo-7/?ref=lbp
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="source"></param>
        /// <param name="totalNodes"></param>
        public int[] CalculatesShortesPath(int[,] graph, int source, int totalNodes)
        {
            int[] nodeDistances = new int[totalNodes];

            bool[] visitedNodes = new bool[totalNodes];

            for (int i = 0; i < totalNodes; i++)
            {
                nodeDistances[i] = MaxIndex;
            }

            nodeDistances[source] = 0;

            for (int count = 0; count < totalNodes; count++)
            {
                int closestNodeIndex = GetClosestUnvisitedNodeIndex(nodeDistances, visitedNodes, totalNodes);

                visitedNodes[closestNodeIndex] = true;

                for (int index = 0; index < totalNodes; index++)
                {
                    if (!visitedNodes[index]
                        // has link
                        && graph[closestNodeIndex, index] != 0
                        // the min distance is shorter than the distance of the current node
                        && nodeDistances[closestNodeIndex] + graph[closestNodeIndex, index] < nodeDistances[index])
                    {
                        nodeDistances[index] = nodeDistances[closestNodeIndex] + graph[closestNodeIndex, index];
                    }
                }
            }

            return nodeDistances;
        }

        private static int GetClosestUnvisitedNodeIndex(int[] nodeDistances, bool[] visitedNodes, int totalNodes)
        {
            int minNodeIndex = -1;
            int nodeDistance = MaxIndex;

            for (int i = 0; i < totalNodes; i++)
            {
                if (!visitedNodes[i] && nodeDistances[i] <= nodeDistance)
                {
                    nodeDistance = nodeDistances[i];
                    minNodeIndex = i;
                }
            }

            return minNodeIndex;
        }
    }
}
