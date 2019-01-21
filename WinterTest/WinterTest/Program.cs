using System;

namespace WinterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
        private void Run()
        {
            Console.Clear();
            Console.Write("Please enter first name : ");
            string firstName = Console.ReadLine();
            Console.Write("Please enter last name : ");
            string lastName = Console.ReadLine();
            Game game = new Game();
            game.RunGame(new Player(firstName, lastName));
        }
    }
}
