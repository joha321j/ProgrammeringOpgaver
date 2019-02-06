using System;
using System.Collections.Generic;
using BadCode.Application;
using BadCode.Exceptions;


namespace BadCode.UI
{
    public class Menu
    {
        private readonly Controller _controller;

        public Menu()
        {
            _controller = new Controller();
            Initialise();
        }

        private void Initialise()
        {
            Console.WriteLine("Initialiserer \"BADCODE\"...");
            Console.WriteLine("Registrerer spillere...");
            Console.WriteLine("Registrerer teams...");
            Console.WriteLine("Tilføjer spillere til teams...");
            Console.WriteLine("Registrerer Liga...");
            Console.WriteLine("Tilføjer teams til Liga...");
            Console.WriteLine("Planlægger 1. runde...");
            Console.ReadKey();
            Console.Clear();
            _controller.InitialiseTestTournament();
        }

        private void ShowScore()
        {
            Console.Write("Angiv navn på liga: ");
            string tournamentName = Console.ReadLine();
            int numberOfRounds = _controller.GetNumberOfRounds(tournamentName);
            int numberOfMatches = _controller.GetNumberOfMatches(tournamentName);

            List<string> teamScores = _controller.GetScore(tournamentName);
            Console.Clear();
            Console.WriteLine("  #####");
            Console.WriteLine(" #     # ##### # #      #      # #    #  ####  ");
            Console.WriteLine(" #         #   # #      #      # ##   # #    # ");
            Console.WriteLine("  #####    #   # #      #      # # #  # #      ");
            Console.WriteLine("       #   #   # #      #      # #  # # #  ### ");
            Console.WriteLine(" #     #   #   # #      #      # #   ## #    # ");
            Console.WriteLine("  #####    #   # ###### ###### # #    #  #### ");
            Console.WriteLine("0--------------------------------------------------0");
            Console.WriteLine($"|      Liga : {tournamentName}                     |");
            Console.WriteLine($"|      Spillede runder : {numberOfRounds}                         |");
            Console.WriteLine($"|      Spillede kampe : {numberOfMatches}                         |");
            Console.WriteLine("-----------------------------------| Vundne kampe  |");

            for (int i = 0; i < teamScores.Count; i++)
            {
                Console.WriteLine(teamScores[i]);
            }

            Console.WriteLine("0--------------------------------------------------0\n");
        }

        public void RunMenu()
        {

            bool running = true;
            do
            {
                Console.WriteLine("Dragons Lair");
                Console.WriteLine();
                Console.WriteLine("1. Præsenter ligastilling");
                Console.WriteLine("2. Planlæg runde i liga");
                Console.WriteLine("3. Afvikl kamp");
                Console.WriteLine("4. Vis kampe der skal spilles");
                Console.WriteLine();
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Indtast dit valg: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1" :
                        ShowScore();
                        break;
                    case "2":
                        ScheduleNewRound();
                        break;
                    case "3":
                        RegisterMatch();
                        break;
                    case "4":
                        ShowMatchUps();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ReadLine();
                        break;
                }
            } while (running);
        }

        private void ShowMatchUps()
        {
            List<string> matchUps;

            Console.Write("Angiv navn på liga: ");
            string tournamentName = Console.ReadLine();
            matchUps = _controller.GetMatchUps(tournamentName, out int roundNo);
            int i = 1;
            Console.WriteLine($"Dette er kampene for runde {roundNo}");

            foreach (string matchUp in matchUps)
            {
                string[] matchStrings = matchUp.Split(';');

                Console.WriteLine($"{i}: {matchStrings[0]} mod {matchStrings[1]}");
                i++;

            }
            
            Console.WriteLine("--------------------------------------------------");
            Console.ReadKey();
            Console.Clear();
        }

        private void RegisterMatch()
        {
            Console.Write("Angiv navn på liga: ");
            string tournamentName = Console.ReadLine();
            Console.Write("Angiv runde: ");
            string round = Console.ReadLine();
            if (round != null)
            {
                int roundnr = int.Parse(round);
                Console.Write("Angiv første modstander: ");
                string opponent1 = Console.ReadLine();
                Console.Write("Angiv anden modstander: ");
                string opponent2 = Console.ReadLine();
                Console.Write("Angiv vinderhold: ");
                string winner = Console.ReadLine();
                Console.Clear();
                _controller.SaveMatch(tournamentName, roundnr, opponent1, opponent2, winner);
            }
        }

        private void ScheduleNewRound()
        {
            Console.Write("Angiv navn på liga: ");
            string tournamentName = Console.ReadLine();

            try
            {
                List<string> roundMatchups = _controller.ScheduleNewRound(tournamentName);
                int numberOfRounds = _controller.GetNumberOfRounds(tournamentName);

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("        Liga: " + tournamentName);
                Console.WriteLine("          Runde " + numberOfRounds);
                Console.WriteLine("-----------------------------------------");

                foreach (string roundMatchup in roundMatchups)
                {
                    Console.WriteLine(roundMatchup);
                }
                Console.WriteLine("-----------------------------------------");
                Console.Write("Tryk på en vilkårlig tast...");
                Console.ReadKey();
                Console.Clear();

            }
            catch (TournamentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}