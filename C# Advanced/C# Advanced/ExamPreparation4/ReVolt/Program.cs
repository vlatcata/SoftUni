using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;
            bool win = false;

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = input[col];

                    if (input[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();

                field[playerRow, playerCol] = '-';

                playerRow = MoveRow(playerRow, command);
                playerCol = MoveCol(playerCol, command);

                if (!IsPositionInField(playerRow, playerCol, size))
                {
                    switch (command)
                    {
                        case "up":
                            playerRow = size - 1;
                            break;
                        case "down":
                            playerRow = 0;
                            break;
                        case "left":
                            playerCol = size - 1;
                            break;
                        case "right":
                            playerCol = 0;
                            break;
                    }
                }

                if (field[playerRow, playerCol] == 'B')
                {
                    switch (command)
                    {
                        case "up":
                            playerRow--;
                            break;
                        case "down":
                            playerRow++;
                            break;
                        case "left":
                            playerCol--;
                            break;
                        case "right":
                            playerCol++;
                            break;
                    }

                    if (!IsPositionInField(playerRow, playerCol, size))
                    {
                        switch (command)
                        {
                            case "up":
                                playerRow = size - 1;
                                break;
                            case "down":
                                playerRow = 0;
                                break;
                            case "left":
                                playerCol = size - 1;
                                break;
                            case "right":
                                playerCol = 0;
                                break;
                        }
                    }
                }

                if (field[playerRow, playerCol] == 'T')
                {
                    switch (command)
                    {
                        case "up":
                            playerRow++;
                            break;
                        case "down":
                            playerRow--;
                            break;
                        case "left":
                            playerCol++;
                            break;
                        case "right":
                            playerCol--;
                            break;
                    }
                }

                if (field[playerRow, playerCol] == 'F')
                {
                    field[playerRow, playerCol] = 'f';
                    win = true;
                    break;
                }

                field[playerRow, playerCol] = 'f';
            }

            if (win)
            {
                Console.WriteLine($"Player won!");
            }
            else
            {
                Console.WriteLine($"Player lost!");
            }

            PrintTerritory(field);
        }

        private static bool IsPositionInField(int row, int col, int size)
        {
            if (row < 0 || row >= size)
            {
                return false;
            }
            if (col < 0 || col >= size)
            {
                return false;
            }

            return true;
        }

        private static void PrintTerritory(char[,] territory)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int MoveRow(int row, string movement)
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

        private static int MoveCol(int col, string movement)
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