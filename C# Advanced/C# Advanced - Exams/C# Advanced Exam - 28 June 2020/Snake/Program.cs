using System;
using System.Linq;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int snakeRow = 0;
            int snakeCol = 0;
            int food = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            while (true)
            {
                matrix[snakeRow, snakeCol] = '.';
                snakeRow = MoveRow(snakeRow, command);
                snakeCol = MoveCol(snakeCol, command);

                if (IsPositionValid(snakeRow, snakeCol, n, n))
                {
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        matrix[snakeRow, snakeCol] = 'S';
                        food++;
                    }

                    if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        int lairRow = 0;
                        int lairCol = 0;

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    lairRow = row;
                                    lairCol = col;
                                }
                            }
                        }
                        snakeRow = lairRow;
                        snakeCol = lairCol;
                        matrix[snakeRow, snakeCol] = 'S';
                    }

                    if (food >= 10)
                    {
                        Console.WriteLine("You won! You fed the snake.");
                        Console.WriteLine($"Food eaten: {food}");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {food}");
                    break;
                }
                command = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
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
