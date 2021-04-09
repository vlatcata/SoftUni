using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double health;
		private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            BaseHealth = health;
            Armor = armor;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }


        public string Name
        {
            get
            {
				return name;
            }
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

				name = value;
            }
        }

		public double BaseHealth { get; private set; }
        
		public double Health
        {
            get
            {
				return health;
            }
			set
            {
                if (value > 0)
                {
                    health = value;
                }
            }
        }

		public double BaseArmor { get; private set; }

		public double Armor
        {
            get
            {
                return armor;
            }
            private set
            {
                if (value > 0)
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }


        public Bag Bag { get; private set; }

		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (armor >= 0)
            {
                double damageToTake = hitPoints - armor;
                armor -= hitPoints;
                if (armor <= 0)
                {
                    armor = 0;
                    health -= damageToTake;
                }
            }
            else
            {
                health -= hitPoints;
            }

            if (health <= 0)
            {
                IsAlive = false;
                health = 0;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            string status = "";
            if (this.IsAlive)
            {
                status = "Alive";
            }
            else
            {
                status = "Dead";
            }
            return $"{name} - HP: {health}/{BaseHealth}, AP: {armor}/{BaseArmor}, Status: {status}";
        }
    }
}