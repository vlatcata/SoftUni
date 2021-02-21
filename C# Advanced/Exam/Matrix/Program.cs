using System;
using System.Linq;

namespace Warships
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] attackCoordinates = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            char[,] field = new char[n, n];

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int shipsDestroyed = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            for (int i = 0; i < attackCoordinates.Length; i++)
            {
                string[] currentCoordinates = attackCoordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int attackRow = int.Parse(currentCoordinates[0]);
                int attackCol = int.Parse(currentCoordinates[1]);

                if (attackRow < 0 || attackRow >= n || attackCol < 0 || attackCol >= n)
                {
                    continue;
                }

                if (field[attackRow, attackCol] == '<')
                {
                    firstPlayerShips--;
                    shipsDestroyed++;
                    field[attackRow, attackCol] = 'X';
                }
                else if (field[attackRow, attackCol] == '>')
                {
                    secondPlayerShips--;
                    shipsDestroyed++;
                    field[attackRow, attackCol] = 'X';
                }
                else if (field[attackRow, attackCol] == '#')
                {
                    field[attackRow, attackCol] = 'X';

                    int startRow = 0;
                    int startCol = 0;
                    int endRow = 0;
                    int endCol = 0;

                    if (attackRow > 0)
                    {
                        startRow = attackRow - 1;
                    }

                    if (attackRow < n - 1)
                    {
                        endRow = attackRow + 1;
                    }

                    if (attackRow == n - 1)
                    {
                        endRow = n - 1;
                    }

                    if (attackCol > 0)
                    {
                        startCol = attackCol - 1;
                    }

                    if (attackCol < n - 1)
                    {
                        endCol = attackCol + 1;
                    }

                    if (attackCol == n - 1)
                    {
                        endCol = n - 1;
                    }

                    for (int row = startRow; row <= endRow; row++)
                    {
                        for (int col = startCol; col <= endCol; col++)
                        {
                            if (field[row, col] == '<')
                            {
                                firstPlayerShips--;
                                shipsDestroyed++;
                                field[row, col] = 'X';
                            }
                            else if (field[row, col] == '>')
                            {
                                secondPlayerShips--;
                                shipsDestroyed++;
                                field[row, col] = 'X';
                            }
                        }
                    }
                }

                if (secondPlayerShips == 0)
                {
                    Console.WriteLine($"Player One has won the game! {shipsDestroyed} ships have been sunk in the battle.");
                    return;
                }

                if (firstPlayerShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {shipsDestroyed} ships have been sunk in the battle.");
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
        }
    }
}