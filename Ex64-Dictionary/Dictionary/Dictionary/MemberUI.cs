using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    public delegate Member EnterMemberDelegate();

    class MemberUI
    {
        public static char ExitValue = '0';
        private readonly char[] _legalChoices = { ExitValue, '1', '2', '3', '4' };
        public MemberController Mc { get; set; }

        public MemberUI(MemberController memberController)
        {
            Mc = memberController;
        }

        public void Run()
        {
            bool running;
            char choice;
            do
            {
                ShowMenu();
                choice = GetChoice();
                running = (choice != ExitValue);
                if (running)
                {
                    MenuAction(choice);
                }
            } while (running);
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Tilføj aktivt medlem");
            Console.WriteLine("2 - Tilføj passivt medlem");
            Console.WriteLine("3 - Slet et medlem");
            Console.WriteLine("4 - Vis alle medlemmer");
            Console.WriteLine("");
            Console.WriteLine(ExitValue + " - Afslut");
            Console.WriteLine("");
        }

        private char GetChoice()
        {
            char input;
            bool ok;
            do
            {
                Console.Write("Indtast dit valg : ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                ok = _legalChoices.Contains(input);
                if (!ok)
                {
                    Console.WriteLine($"Input er ikke gyldigt - {input} er ikke et muligt valg. Prøv venligst igen.");
                }
            } while (!ok);
            Console.Clear();
            return input;
        }

        private void MenuAction(char choice)
        {
            switch (choice)
            {
                case '1':
                    Mc.AddMember(MemberType.active, EnterMember());
                    break;
                case '2':
                    Mc.AddMember(MemberType.passive, EnterMember());
                    break;
                case '3':
                    Mc.DeleteMember(EnterId());
                    break;
                case '4':
                    ShowMembers();
                    break;
            }
        }

        private void ShowMembers()
        {

            //Pre: None
            //Post: None
            //Output: All members (active and passive) are listed on the screen

            Console.WriteLine("Alle medlemmer : ");
            List<string> memberStrings = Mc.GetMembers().ToList();
            foreach (string memberString in memberStrings)
            {
                Console.WriteLine(memberString);
            }
            Pause();
        }

        public void Pause()
        {
            Console.Write("Tryk på en tast for at fortsætte...");
            Console.ReadKey();
        }

        public int EnterId()
        {
            bool ok;
            int id;
             
            do
            {
                Console.Write("Indtast Id : ");
                ok = int.TryParse(Console.ReadLine(), out id);
                if (ok == false)
                {
                    Console.WriteLine("Id skal være et heltal. Prøv venligst igen - tast " +
                        ExitValue + " for at fortryde.");
                }
            } while (ok == false);
            return id;
        }

        public string EnterName()
        {
            Console.Write("Indtast navn : ");
            return Console.ReadLine();
        }

        public Member EnterMember()
        {
            Member result = null;

            int id = EnterId();
            if (Mc.IdAlreadyUsed(id))
            {
                Console.WriteLine("Id er allerede i brug. ");
                Pause();
            }
            else
            {
                if (id != ExitValue)
                {
                    result = new Member() { Id = id, Name = EnterName() };
                }
            }
            return result;
        }
    }
}

