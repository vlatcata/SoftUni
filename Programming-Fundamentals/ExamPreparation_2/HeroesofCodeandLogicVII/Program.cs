using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesofCodeandLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroHp = new Dictionary<string, int>(); 
            var heroMp = new Dictionary<string, int>(); 

            int n = int.Parse(Console.ReadLine());
            int hpMax = 100;
            int mpMax = 200;

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();

                string heroName = cmdArg[0];
                int hp = int.Parse(cmdArg[1]);
                int mp = int.Parse(cmdArg[2]);

                heroHp[heroName] = hp > hpMax ? hpMax : hp;
                heroMp[heroName] = mp > mpMax ? mpMax : mp;
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArg = command.Split(" - ");
                string cmd = cmdArg[0];
                string heroName = cmdArg[1];

                if (cmd == "CastSpell")
                {
                    int mpNeeded = int.Parse(cmdArg[2]);
                    string spellName = cmdArg[3];

                    if (heroMp[heroName] >= mpNeeded)
                    {
                        heroMp[heroName] -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroMp[heroName]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (cmd == "TakeDamage")
                {
                    int damage = int.Parse(cmdArg[2]);
                    string attacker = cmdArg[3];

                    heroHp[heroName] -= damage;

                    if (heroHp[heroName] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroHp[heroName]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroHp.Remove(heroName);
                        heroMp.Remove(heroName);
                    }
                }
                else if (cmd == "Recharge")
                {
                    int amount = int.Parse(cmdArg[2]);
                    int mpBefore = heroMp[heroName];
                    heroMp[heroName] += amount;

                    if (heroMp[heroName] > mpMax)
                    {
                        heroMp[heroName] = mpMax;
                    }

                    int mpAfter = heroMp[heroName];
                    int totalAmount = mpAfter - mpBefore;

                    Console.WriteLine($"{heroName} recharged for {totalAmount} MP!");
                }
                else if (cmd == "Heal")
                {
                    int amount = int.Parse(cmdArg[2]);
                    int hpBefore = heroHp[heroName];
                    heroHp[heroName] += amount;

                    if (heroHp[heroName] > hpMax)
                    {
                        heroHp[heroName] = hpMax;
                    }

                    int hpAfter = heroHp[heroName];
                    int totalAmount = hpAfter - hpBefore;

                    Console.WriteLine($"{heroName} healed for {totalAmount} HP!");
                }

                command = Console.ReadLine();
            }

            foreach (var hero in heroHp.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value}");
                Console.WriteLine($"  MP: {heroMp[hero.Key]}");
            }
        }
    }
}
