namespace Interview.Samples.Application.Arrays
{
    public class IslandPerimeter
    {
        private const int MinTreshold = 1;
        private const int MaxTreshold = 100;

        public int Calculate(int[,] grid)
        {
            if (grid.GetLength(0) < MinTreshold || grid.GetLength(0) > MaxTreshold)
            {
                return 0;
            }

            if (grid.GetLength(1) < MinTreshold || grid.GetLength(1) > MaxTreshold)
            {
                return 0;
            }

            var perimeter = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    // validate if the cell is a land - 1
                    if ((grid[row, col] == 0))
                    {
                        // water get next cell
                        continue;
                    }

                    perimeter = UpdatePerimeter(grid, perimeter, row, col);
                }
            }
            
            return perimeter;
        }

        private static int UpdatePerimeter(int[,] grid, int perimeter, int row, int col)
        {
            if (row == 0 || grid[row - 1, col] == 0)
            {
                // TL
                perimeter++;
            }

            if (row == grid.GetLength(0) - 1 || grid[row + 1, col] == 0)
            {
                // BL
                perimeter++;
            }

            if (col == 0 || grid[row, col - 1] == 0)
            {
                // TR
                perimeter++;
            }

            if (col == grid.GetLength(1) - 1 || grid[row, col + 1] == 0)
            {
                // BR
                perimeter++;
            }

            return perimeter;
        }
    }
}
