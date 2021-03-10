using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = null;

                if (type == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                if (type == nameof(Druid))
                {
                    hero = new Druid(name);
                }
                else if (type == nameof(Paladin))
                {
                    hero = new Paladin(name);
                }
                else if (type == nameof(Rogue))
                {
                    hero = new Rogue(name);
                }
                else if (type == nameof(Warrior))
                {
                    hero = new Warrior(name);
                }

                heroes.Add(hero);
            }

            int bossHP = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                bossHP -= hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (bossHP <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
