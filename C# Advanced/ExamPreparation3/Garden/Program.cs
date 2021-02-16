using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] garden = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = garden[0];
            int m = garden[1];

            int[,] matrix = new int[n,m];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = matrix[0,0];
                }
            }

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                int[] position = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int flowerRow = position[0];
                int flowerCol = position[1];

                if (!IsPositionValid(flowerRow, flowerCol, n, m))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int row = flowerRow; row < flowerRow + 1; row++) //same row
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            matrix[row, col]++;
                        }
                    }
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = flowerCol; col < flowerCol + 1; col++) // same col
                        {
                            if (row == flowerRow && col == flowerCol)
                            {
                                continue;
                            }
                            matrix[row, col]++;
                        }
                    }
                }

                command = Console.ReadLine();
            }
            

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }
    }
}
