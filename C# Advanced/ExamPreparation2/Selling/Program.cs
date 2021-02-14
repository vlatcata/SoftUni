using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            int money = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            while (true)
            {
                matrix[playerRow, playerCol] = '-';
                playerRow = MoveRow(playerRow, command);
                playerCol = MoveCol(playerCol, command);

                if (!IsPositionValid(playerRow, playerCol, n, n))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {money}");
                    break;
                }

                if (Char.IsDigit(matrix[playerRow, playerCol]))
                {
                    money += int.Parse(matrix[playerRow, playerCol].ToString());
                    matrix[playerRow, playerCol] = 'S';
                }

                if (matrix[playerRow, playerCol] == 'O')
                {
                    matrix[playerRow, playerCol] = '-';
                    int pilarRow = 0;
                    int pilarCol = 0;

                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                pilarRow = row;
                                pilarCol = col;
                            }
                        }
                    }

                    playerRow = pilarRow;
                    playerCol = pilarCol;
                }

                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {money}");
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
    }
}
