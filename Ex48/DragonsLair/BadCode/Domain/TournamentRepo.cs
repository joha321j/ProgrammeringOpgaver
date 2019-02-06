using System.Collections.Generic;

namespace BadCode.Domain
{
    class TournamentRepo
    {
        private readonly List<Tournament> _tournaments = new List<Tournament>();

        public void RegisterTournament(string name)
        {
            Tournament newTournament = new Tournament(name);
            RegisterTournament(newTournament);
        }

        public void RegisterTournament(Tournament tournament)
        {
            _tournaments.Add(tournament);
        }

        public Tournament GetTournament(string x)
        {
            Tournament y = null;
            int idx = 0;
            while((y == null) && (idx < _tournaments.Count))
            {
                if (_tournaments[idx].Name.Equals(x))
                {
                    y = _tournaments[idx];
                }
                idx++;
            }
            return y;
        }
    }
}
