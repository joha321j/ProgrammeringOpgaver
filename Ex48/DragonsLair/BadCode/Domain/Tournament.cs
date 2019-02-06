using System;
using System.Collections.Generic;
using BadCode.Exceptions;

namespace BadCode.Domain
{
    public class Tournament
    {
        public enum State { STANDBY, ACTIVE, FINISHED };

        public string Name { get; set; }
        public State Status { get; set; }

        private readonly TeamRepo _teams = new TeamRepo();
        private readonly List<Round> _rounds = new List<Round>();

        public Tournament(string tournamentName)
        {
            Name = tournamentName;
            Status = State.STANDBY;
        }

        public Tournament(string tournamentName, State status)
        {
            Name = tournamentName;
            Status = status;
        }

        public void AddTeam(Team t)
        {
            _teams.RegisterTeam(t);
        }

        public Team GetTeam(string name)
        {
            return _teams.GetTeam(name);
        }

        public List<Team> Teams()
        {
            return _teams.Teams();
        }

        public int GetNumberOfRounds()
        {
            return _rounds.Count;
        }

        public Round GetRound(int idx)
        {
            return _rounds[idx - 1]; //Første runde er No. 1, men index 0
        }

        public void AddRound(Round r)
        {
            _rounds.Add(r);
        }

        public override string ToString()
        {
            return Name;
        }

        public Dictionary<string, int> GetScore(Dictionary<string, int> teamNameToScore)
        {
            int numberOfRounds = GetNumberOfRounds();
            if (numberOfRounds > 0)
            {
                int numberOfMatches = 0;
                for (int i = 1; i <= numberOfRounds; i++)
                {
                    Round currentRound = GetRound(i);
                    numberOfMatches = numberOfMatches + currentRound.GetNumberOfMatches();
                    foreach (Team winningTeam in currentRound.WinningTeams)
                    {
                        if (!teamNameToScore.ContainsKey(winningTeam.Name))
                        {
                            teamNameToScore.Add(winningTeam.Name, 0);
                        }
                        teamNameToScore[winningTeam.Name] = teamNameToScore[winningTeam.Name] + 1;
                    }
                }
            }

            return teamNameToScore;
        }

        public int GetNumberOfFinishedMatches()
        {
            int numberOfMatches = 0;
            foreach (Round round in _rounds)
            {
                if (round.IsRoundFinished())
                {
                    numberOfMatches += round.GetNumberOfMatches();
                }
            }

            return numberOfMatches;
        }

        public int GetNumberOfFinishedRounds()
        {
            int numberOfRounds = 0;

            foreach (Round round in _rounds)
            {
                if (round.IsRoundFinished())
                {
                    numberOfRounds++;
                }
            }

            return numberOfRounds;
        }

        public List<string> ScheduleNewRound(out string freeRider)
        {
            List<string> roundMatchUps = new List<string>();

            int numberOfRounds = GetNumberOfRounds();
            List<Team> teams;
            Round thisRound = null;

            freeRider = "NULL";

            //Get teams for new round
            if (numberOfRounds == 0) //SPECIAL CASE: Initialize first round. Handled by adding all teams from tournament 
            {
                teams = Teams();
            }
            else // We are scheduling round > 0, get winners from this round if it is finished
            {
                thisRound = GetRound(numberOfRounds);
                if (thisRound.IsRoundFinished())
                {
                    teams = thisRound.WinningTeams;
                    if (thisRound.FreeRider != null)
                    {
                        teams.Add(thisRound.FreeRider);
                    }
                }
                else
                {
                    throw new TournamentException("Round is not finished");
                }
            }

            if (teams.Count < 2)
            {
                Status = State.FINISHED;
            }
            else
            {
                Round newRound = new Round();

                //Manage freeRiders
                if (teams.Count % 2 != 0) //Select Address freeRider
                {
                    //If prior round exists and it had Address freeRider and if was first team the select second team
                    if ((numberOfRounds > 0) && (thisRound?.FreeRider != null) && (thisRound.FreeRider.Equals(teams[0])))
                    {
                        newRound.FreeRider = teams[1];
                        teams.Remove(teams[1]);
                    }
                    else //select first team
                    {
                        newRound.FreeRider = teams[0];
                        teams.Remove(teams[0]);
                    }
                }

                Random r = new Random();
                List<int> randomIndices = new List<int>();

                for (int i = 0; i < teams.Count; i++)
                {
                    randomIndices.Add(i);
                }
                for (int i = 0; i < 100; i++)
                {
                    int idx1 = r.Next(teams.Count);
                    int idx2 = r.Next(teams.Count);
                    int temp = randomIndices[idx1];
                    randomIndices[idx1] = randomIndices[idx2];
                    randomIndices[idx2] = temp;
                }

                int noOfMatches = teams.Count / 2;
                for (int i = 0; i < noOfMatches; i++)
                {
                    Match newMatch = new Match
                    {
                        FirstOpponent = teams[randomIndices[2 * i]],
                        SecondOpponent = teams[randomIndices[2 * i + 1]]
                    };
                    newRound.AddMatch(newMatch);
                }
                AddRound(newRound);
                int matchNo = 1;

                foreach (Match m in newRound.GetAllMatches())
                {
                    string first = m.FirstOpponent.Name;
                    string second = m.SecondOpponent.Name;

                    roundMatchUps.Add($"{matchNo};{first};{second}");
                    matchNo++;
                }

                if (newRound.FreeRider != null)
                {
                    freeRider = newRound.FreeRider.Name;
                }

            }


            return roundMatchUps;
        }

        public void SaveMatch(int roundNumber, string team1, string team2, string winningTeam)
        {
            Round selectedRound = GetRound(roundNumber);
            Match m = selectedRound.GetMatch(team1, team2);

            if (m == null)
            {
                throw new TournamentException("These teams do not play each other.");
            }

            m.Winner = GetTeam(winningTeam);

        }

        public List<string> GetMatchUps()
        {
            return GetRound(GetNumberOfRounds()).GetAllMatches().ConvertAll(match => match.ToString());
        }
    }
}
