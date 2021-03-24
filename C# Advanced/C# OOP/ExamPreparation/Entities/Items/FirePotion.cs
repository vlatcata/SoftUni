using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    class FirePotion : Item
    {
        private const int customWeight = 5;
        public FirePotion(int weight) : base(customWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {

            }
        }
    }
}
