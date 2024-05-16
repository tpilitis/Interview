namespace Interview.Samples.Application
{
    /// <summary>
    /// https://leetcode.com/problems/pascals-triangle/description/
    /// </summary>
    public static class PascalTriangleService
    {
        public static int[][] GenerateTriangle(int rows)
        {
            if (rows < 1 || rows >= 30)
            {
                return Array.Empty<int[]>();
            }

            var pascalTriangle = new int[rows][];

            // 1st element is always 1            
            pascalTriangle[0] = [1];

            for (int i = 1; i < rows; i++)
            {
                pascalTriangle[i] = new int[i + 1];

                // 1st element always is 1
                pascalTriangle[i][0] = 1;
                for (int j = 1; j < i+1; j++)
                {
                    // last element
                    if (j == i)
                    {
                        pascalTriangle[i][j] = 1;
                    }
                    else
                    {
                        pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                    }
                }
            }

            return pascalTriangle;
        }
    }
}
