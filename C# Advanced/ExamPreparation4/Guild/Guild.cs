using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> data;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Player>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }


        public void AddPlayer(Player player)
        {
            if (data.Count < Capacity)
            {
                data.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = data.FirstOrDefault(x => x.Name == name);
            if (data.Contains(player))
            {
                data.Remove(player);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = data.FirstOrDefault(x => x.Name == name && x.Rank != "Member");
            if (data.Contains(player))
            {
                if (player != null)
                {
                    player.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = data.FirstOrDefault(x => x.Name == name && x.Rank != "Trial");
            if (data.Contains(player))
            {
                if (player != null)
                {
                    player.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            List<Player> players = new List<Player>();
            foreach (Player player in data)
            {
                if (player.Class == clas)
                {
                    players.Add(player);
                }
            }
            data = data.Where(x=>x.Class != clas).ToList();
            return players.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (Player player in data)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
