using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string name;
        private double baseHealth;
        private double maxHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;


        public Character(string name, double armor, double abilityPoints, IBag bag)
        {
            Name = name;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
		{
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
		}

        public double BaseHealth
        {
            get
            {
                return baseHealth;
            }
            set
            {
                if (BaseHealth > value)
                {
                    baseHealth = value;
                }
                baseHealth = value;
                maxHealth = value;
            }
        }

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (health > maxHealth)
                {
                    throw new ArgumentException("Health cannot be more than max health");
                }
                if (health < 0)
                {
                    throw new ArgumentException("Health cannot be less than 0");
                }
                health = value;
            }
        }

        public double BaseArmor
        {
            get
            {
                return baseArmor;
            }
            set
            {
                baseArmor = value;
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Armor cannot be less than 0");
                }
                armor = value;
            }
        }

        public double AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
            set
            {
                abilityPoints = value;
            }
        }


        public bool IsAlive { get; set; } = true;

        public IBag Bag { get; set; }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                Armor -= hitPoints;

                if (armor - hitPoints <= 0 || armor <= 0)
                {
                    armor = 0;
                    double damageToTake = Armor - hitPoints;
                    Health -= damageToTake;
                }
                
                if (health <= 0)
                {
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter();
            }
        }
	}
}