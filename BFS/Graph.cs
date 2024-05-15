namespace Interview.Samples.BFS
{
    public class Graph
    {
        public Graph(int nodes)
        {
            Nodes = nodes;

            Links = new List<int>[nodes];
            for (int i = 0; i < Nodes; i++)
            {
                Links[i] = new List<int>();
            }
        }

        public Graph(int[,] links)
        {
            MaxNodeValue = 0;
            for (int index = 0; index < links.GetLength(0); index++)
            {
                MaxNodeValue = Math.Max(MaxNodeValue, Math.Max(links[index, 0], links[index, 1]));
            }

            // Creating adjacency list
            Nodes = MaxNodeValue + 1;
            Links = new List<int>[Nodes];
            for (int index = 0; index <= MaxNodeValue; index++)
            {
                Links[index] = [];
            }

            for (int index = 0; index < Links.GetLength(0) - 1; index++)
            {
                Links[links[index, 0]].Add(links[index, 1]);
                Links[links[index, 1]].Add(links[index, 0]);
            }
        }

        /// <summary>
        /// Nodes == vertices
        /// </summary>
        public int Nodes { get; set; }

        /// <summary>
        /// Link == Edges
        /// </summary>
        public List<int>[] Links { get; set; }

        public int MaxNodeValue { get; set; }

        /// <summary>
        /// Add Links
        /// </summary>
        /// <param name="node"></param>
        /// <param name="neighbour"></param>
        public void AddLink(int node, int neighbour) => Links[node].Add(neighbour);

        public List<int> BreathFirstSearch(int startNode)
        {
            Queue<int> queue = new Queue<int>();

            bool[] visitedNodes = new bool[Nodes];

            // mark the current node as visited
            visitedNodes[startNode] = true;
            queue.Enqueue(startNode);

            Console.WriteLine($"Breadth First Traversal starting from node: {startNode}");

            var output = new List<int>();
            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                Console.WriteLine($"{currentNode} ");
                output.Add(currentNode);

                foreach (var neighbor in Links[currentNode])
                {
                    if (visitedNodes[neighbor])
                    {
                        continue;
                    }

                    visitedNodes[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }

            return output;
        }

        public int FindNodeLevel(int startNode, int searchNode)
        {
            if (searchNode > MaxNodeValue || !Links.Any())
            {
                return -1;
            }

            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            var level = 0;
            bool[] visited = new bool[Nodes];
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var queuCount = queue.Count;

                while (queuCount-- != 0)
                {
                    int currentNode = queue.Dequeue();
                    if (currentNode == searchNode)
                    {
                        return level;
                    }

                    foreach (var link in Links[currentNode])
                    {
                        if (visited[link])
                            continue;

                        queue.Enqueue(link);
                        visited[link] = true;
                    } 
                }
    
                level++;
            }

            return -1;
        }
    }
}
