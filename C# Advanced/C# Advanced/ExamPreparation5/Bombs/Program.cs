using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeBombs = 0;
            int daturaBombValue = 40;
            int cherryBombValue = 60;
            int smokeBombValue = 120;
            bool bombPouchFilled = false;

            while (effects.Count > 0 && casings.Count > 0 || bombPouchFilled == true)
            {
                int effect = effects.Peek();
                int casing = casings.Peek();

                int sum = effect + casing;

                if (sum == daturaBombValue)
                {
                    daturaBombs++;
                    effects.Dequeue();
                    casings.Pop();
                    if (daturaBombs >= 3 && cherryBombs >= 3 && smokeBombs >= 3)
                    {
                        bombPouchFilled = true;
                        break;
                    }
                    continue;
                }
                else if (sum == cherryBombValue)
                {
                    cherryBombs++;
                    effects.Dequeue();
                    casings.Pop();
                    if (daturaBombs >= 3 && cherryBombs >= 3 && smokeBombs >= 3)
                    {
                        bombPouchFilled = true;
                        break;
                    }
                    continue;
                }
                else if (sum == smokeBombValue)
                {
                    smokeBombs++;
                    effects.Dequeue();
                    casings.Pop();
                    if (daturaBombs >= 3 && cherryBombs >= 3 && smokeBombs >= 3)
                    {
                        bombPouchFilled = true;
                        break;
                    }
                    continue;
                }

                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeBombs >= 3)
                {
                    bombPouchFilled = true;
                    break;
                }
                int casingtodecrease = casings.Pop();
                casingtodecrease -= 5;
                casings.Push(casingtodecrease);
            }

            if (bombPouchFilled == false)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            if (effects.Count <= 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }

            if (casings.Count <= 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cherry Bombs: {cherryBombs}");
            sb.AppendLine($"Datura Bombs: {daturaBombs}");
            sb.AppendLine($"Smoke Decoy Bombs: {smokeBombs}");
            Console.WriteLine(sb);
        }
    }
}
