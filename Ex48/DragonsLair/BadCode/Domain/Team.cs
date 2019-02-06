using System.Collections.Generic;

namespace BadCode.Domain
{
    public class Team
    {
        public string Name { get; set; }
        private readonly List<Player> _players = new List<Player>();

        public Team(string teamName)
        {
            Name = teamName;
        }

        public void AddPlayer(Player p)
        {
            _players.Add(p);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
