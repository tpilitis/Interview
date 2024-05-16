namespace Interview.Samples.Application
{
    public class FindSafenessPathInGrid
    {
        private static readonly int[][] Directions =
                [
                    [1, 0],
                    [-1, 0],
                    [0, 1],
                    [0, -1],
                ];

        /// <summary>
        /// https://leetcode.com/problems/find-the-safest-path-in-a-grid/description/?envType=daily-question&envId=2024-05-15
        /// </summary>
        public static int FindMaximumSafenessFactor(int[,] grid)
        {
            int totalNodes = grid.GetLength(0);
            if (totalNodes == 1)
            {
                return grid[0, 0] == 1 ? 0 : int.MaxValue;
            }

            // Step 1: Compute min distance for each thief
            int[][] distances = ComputeMinDistanceForThiefs(grid, totalNodes);

            // Step 2: Binary Search
            int left = 0;
            int rigth = distances[0][0];
            int result = 0;

            while (left <= rigth)
            {
                int mid = (left + rigth) / 2;

                if (CanReachEndWithSafeness(distances, mid, totalNodes))
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    rigth = mid - 1;
                }
            }

            return result;
        }

        private static int[][] ComputeMinDistanceForThiefs(int[,] grid, int totalNodes)
        {
            int[][] distances = new int[totalNodes][];
            for (int i = 0; i < totalNodes; i++)
            {
                distances[i] = new int[totalNodes];
                for (int j = 0; j < totalNodes; j++)
                {
                    distances[i][j] = int.MaxValue;
                }
            }

            // BFC - initialize all thief positions
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int row = 0; row < totalNodes; row++)
            {
                for (int col = 0; col < totalNodes; col++)
                {
                    if (grid[row, col] == 1)
                    {
                        queue.Enqueue((row, col));
                        distances[row][col] = 0;
                    }
                }
            }

            while (queue.Count > 0)
            {
                (int row, int col) = queue.Dequeue();

                int currentDistance = distances[row][col];

                foreach (var direction in Directions)
                {
                    int nRow = row + direction[0];
                    int nCol = col + direction[1];

                    if (nRow >= 0 && nRow < totalNodes
                        && nCol >= 0 && nCol < totalNodes
                        // not visited
                        && distances[nRow][nCol] == int.MaxValue)
                    {
                        distances[nRow][nCol] = currentDistance + 1;
                        queue.Enqueue((nRow, nCol));
                    }
                }
            }

            return distances;
        }

        private static bool CanReachEndWithSafeness(int[][] distances, int safeness, int totalNodes)
        {
            bool[,] visited = new bool[totalNodes, totalNodes];

            Queue<(int, int)> queue = new Queue<(int, int)>();

            if (distances[0][0] >= safeness)
            {
                queue.Enqueue((0, 0));
                visited[0, 0] = true;
            }

            while (queue.Count > 0)
            {
                (int row, int col) = queue.Dequeue();

                if (row == totalNodes - 1 && col == totalNodes - 1)
                {
                    // reached the bottom rigth corner of the grid
                    return true;
                }

                foreach (var direction in Directions)
                {
                    int nRow = row + direction[0];
                    int nCol = col + direction[1];

                    if (nRow >= 0 && nRow < totalNodes
                        && nCol >= 0 && nCol < totalNodes
                        // not visited
                        && distances[nRow][nCol] >= safeness)
                    {
                        queue.Enqueue((nRow, nCol));
                        visited[nRow, nCol] = true;
                    }
                }
            }

            return false;
        }

    }
}
