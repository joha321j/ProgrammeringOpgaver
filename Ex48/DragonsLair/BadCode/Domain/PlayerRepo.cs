using System.Collections.Generic;

namespace BadCode.Domain
{
    class PlayerRepo
    {
        private readonly List<Player> _players = new List<Player>();

        public void RegisterPlayer(Player player)
        {
            _players.Add(player);
        }

        public void RegisterPlayer(string name, string address = null, string email = null, string telephone = null)
        {
            Player newPlayer = new Player(name, address, email, telephone);
            RegisterPlayer(newPlayer);
        }

        public Player GetPlayer(string name)
        {
            Player foundPlayer = null;
            int idx = 0;
            while ((foundPlayer == null) && (idx < _players.Count))
            {
                if (_players[idx].Name.Equals(name))
                {
                    foundPlayer = _players[idx];
                }
                idx++;
            }
            return foundPlayer;
        }

    }
}
