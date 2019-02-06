using System.Collections.Generic;
using BadCode.Domain;

namespace BadCode.Application
{
    public class Controller
    {
        private readonly TournamentRepo _tournamentRepository;
        private readonly TeamRepo _teamRepository;
        private readonly PlayerRepo _playerRepository;

        public Controller()
        {
            _teamRepository = new TeamRepo();
            _playerRepository = new PlayerRepo();
            _tournamentRepository = new TournamentRepo();
        }

        public void InitialiseTestTournament()
        {

            string tournamentName = "TestTournament";
            Tournament tournament = new Tournament("TestTournament");

            _playerRepository.RegisterPlayer("Laust Ulriksen");
            _playerRepository.RegisterPlayer("Matthias Therkelsen", null, "matthias@therkelsen.dk", "+45 47002155");
            _playerRepository.RegisterPlayer("Martin Bertelsen", "Nyborgvej 10, Odense", null, "+45 22521112");
            _playerRepository.RegisterPlayer("Line Madsen", "Kochsgade 21, Odense", "linem@msn.dk", "+45 00142563");
            _playerRepository.RegisterPlayer("Jette Detlevsen");

            // initialize with Address default set of teams
            _teamRepository.RegisterTeam("FCK");
            _teamRepository.RegisterTeam("OB");
            _teamRepository.RegisterTeam("BiF");
            _teamRepository.RegisterTeam("Hobro");
            _teamRepository.RegisterTeam("AGF");
            
            // Add players to teams
            Team team1 = _teamRepository.GetTeam("FCK");
            team1.AddPlayer(_playerRepository.GetPlayer("Laust Ulriksen"));
            Team team2 = _teamRepository.GetTeam("OB");
            team1.AddPlayer(_playerRepository.GetPlayer("Matthias Therkelsen"));
            Team team3 = _teamRepository.GetTeam("BiF");
            team3.AddPlayer(_playerRepository.GetPlayer("Martin Bertelsen"));
            Team team4 = _teamRepository.GetTeam("Hobro");
            team4.AddPlayer(_playerRepository.GetPlayer("Line Madsen"));
            Team team5 = _teamRepository.GetTeam("AGF");
            team5.AddPlayer(_playerRepository.GetPlayer("Jette Detlevsen"));


            // initialize with Address default tournament
            _tournamentRepository.RegisterTournament(tournament);

            // Add teams to tournament
            tournament = _tournamentRepository.GetTournament(tournamentName);
            tournament.AddTeam(team1);
            tournament.AddTeam(team2);
            tournament.AddTeam(team3);
            tournament.AddTeam(team4);
            tournament.AddTeam(team5);

            // Initialize first round (this also initializes matches)
            ScheduleNewRound(tournamentName);
        }

        private static string PadSpaceToName(string n, int l)
        {
            for (int i = n.Length; i < l; i++)
            {
                n = n + " ";
            }
            return n;
        }

        private static int GetHighestScore(Dictionary<string, int> teamNameToScore)
        {
            int highestScore = 0;
            foreach (KeyValuePair<string, int> element in teamNameToScore)
            {
                if (highestScore < element.Value)
                {
                    highestScore = element.Value;
                }
            }
            return highestScore;
        }

        public List<string> GetScore(string tournamentName)
        {
            Dictionary<string, int> teamNameToScore = new Dictionary<string, int>();

            Tournament selectedTournament = _tournamentRepository.GetTournament(tournamentName);

            teamNameToScore = selectedTournament.GetScore(teamNameToScore);

            List<string> teamScores = new List<string>();

            if (teamNameToScore.Count > 0)
            { 
                //output in sorted order starting with highest score - find highest score
                int highestScore = GetHighestScore(teamNameToScore);
                


                for (int i = highestScore; i >= 0; i--)
                {
                    foreach (KeyValuePair<string, int> element in teamNameToScore)
                    {
                        if (element.Value == i)
                        {
                            int score = highestScore - i + 1;
                            string name = PadSpaceToName(element.Key, 18);

                            teamScores.Add($"|         {score}. {name}    |      {element.Value}        |");
                        }
                    }
                }  
            }
            return teamScores;
        }

        public List<string> ScheduleNewRound(string tournamentName)
        {
            List<string> roundMatchUps = new List<string>();
            string freeRider;
            List<string> tempList = _tournamentRepository.GetTournament(tournamentName).ScheduleNewRound(out freeRider);

            foreach (string temp in tempList)
            {
                string[] tempSplit = temp.Split(';');

                string matchNo = tempSplit[0];
                string first = tempSplit[1];
                first = PadSpaceToName(first, 10);

                string second = tempSplit[2];

                roundMatchUps.Add($"    {matchNo}. {first}  -  {second}");
            }

            if (!string.Equals(freeRider, "NULL"))
            {
                roundMatchUps.Add("        FreeRider: " + freeRider);
            }

            return roundMatchUps;

        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            _tournamentRepository.GetTournament(tournamentName).SaveMatch(roundNumber, team1, team2, winningTeam);
        }

        public int GetNumberOfRounds(string tournamentName)
        {
            return _tournamentRepository.GetTournament(tournamentName).GetNumberOfFinishedRounds();
        }

        public int GetNumberOfMatches(string tournamentName)
        {
            return  _tournamentRepository.GetTournament(tournamentName).GetNumberOfFinishedMatches();
        }

        public List<string> GetMatchUps(string tournamentName, out int roundNr)
        {
            roundNr = _tournamentRepository.GetTournament(tournamentName).GetNumberOfRounds();
            return _tournamentRepository.GetTournament(tournamentName).GetMatchUps();
        }
    }
}
