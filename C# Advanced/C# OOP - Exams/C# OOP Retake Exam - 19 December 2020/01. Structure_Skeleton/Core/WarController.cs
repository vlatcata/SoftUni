using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characters;
		private List<Item> items;

		public WarController()
		{
			characters = new List<Character>();
			items = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;
            if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
				character = new Priest(name);
            }

            if (character == null)
            {
				throw new ArgumentException(ExceptionMessages.InvalidCharacterType, characterType);
            }

			characters.Add(character);

			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;

            if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
				item = new FirePotion();
            }

            if (item == null)
            {
				throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);
            }

			items.Add(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

            if (items.Count <= 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Item item = this.items.Last();
			character.Bag.AddItem(item);
			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

			Item item = character.Bag.GetItem(itemName);

			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			var sortedCharacters = characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x=>x.Health);

			var result = "";

            foreach (var character in sortedCharacters)
            {
				result += character.ToString() + Environment.NewLine;
            }

			return result;
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Warrior attacker = (Warrior)this.characters.Where(c => c.GetType().Name == nameof(Warrior)).FirstOrDefault(c => c.Name == attackerName);
			Character receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);

			if (attacker == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
			}
            if (receiver == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
			}

			if (!attacker.IsAlive)
			{
				throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attacker));
			}

			if (!receiver.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}

			attacker.Attack(receiver);

			string result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points!" +
				$" {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (receiver.IsAlive == false)
            {
				result += Environment.NewLine + $"{receiver.Name} is dead!";
            }

			return result;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			if (!characters.Any(x => x.Name == healerName))
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
			}
			if (!characters.Any(x => x.Name == healingReceiverName))
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healingReceiverName);
			}
			Character healer = characters.FirstOrDefault(x => x.Name == healerName);
			Character receiver = characters.FirstOrDefault(x => x.Name == healingReceiverName);

			if (healer.GetType().Name != "Priest")
			{
				throw new ArgumentException($"{healer.Name} cannot heal!");
			}

			Priest priest = (Priest)healer;
			priest.Heal(receiver);

			return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name);
		}
	}
}
