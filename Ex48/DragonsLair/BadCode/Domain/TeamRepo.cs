using System.Collections.Generic;

namespace BadCode.Domain
{
    public class TeamRepo
    {
        private readonly List<Team> _teams = new List<Team>();
        
        public void RegisterTeam(Team team)
        {
            _teams.Add(team);
        }

        public void RegisterTeam(string name)
        {
            Team newTeam = new Team(name);
            _teams.Add(newTeam);
        }

        public Team GetTeam(string name)
        {
            Team team = null;
            int idx = 0;
            while ((team == null) && (idx < _teams.Count))
            {
                if (_teams[idx].Name.Equals(name))
                {
                    team = _teams[idx];
                }
                idx++;
            }
            return team;
        }

        public List<Team> Teams()
        {
            return _teams;
        }

    }
}
