﻿using BadCode.UI;

namespace BadCode.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            Menu menu = new Menu();
            menu.RunMenu();
        }
    }
}
