using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28
{
    class Menu
    {
        Controller controller = new Controller();
        public void Show()
        {
            bool running = true;
            

            do
            {
                showMenu();
                string userChoice = GetUserChoice();
                switch (userChoice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        AddPet();
                        break;
                    case "2":
                        ShowAllPets();
                        break;
                    case "3":
                        AddOwner();
                        break;
                    case "4":
                        FindOwnerByEmail();
                        break;
                    case "5":
                        FindOwnerByLastName();
                        break;
                }
            } while (running);
        }

        private void FindOwnerByLastName()
        {
            string lastName = string.Empty;

            while (lastName == string.Empty)
            {
                Console.Clear();

                Console.WriteLine("Indtast efternavn på ejere, der skal findes:");

                lastName = Console.ReadLine();
            }

            controller.FindOwnerByLastName(lastName);
        }

        private void FindOwnerByEmail()
        {
            string email = string.Empty;
            string firstName = string.Empty;

            while (email == string.Empty || firstName == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("Indtast fornavn og email, adskil med mellemrum.");

                string[] inputStrings = Console.ReadLine().Split(' ');
                firstName = inputStrings[0];
                email = inputStrings[1];
            }

            controller.FindOwnerByEmail(firstName, email);
        }

        private void AddOwner()
        {
            string ownerEmail = string.Empty, ownerFirstName = string.Empty, ownerLastName = string.Empty, ownerPhone = string.Empty;
            List<InsertOwnerVariables> ownerVariables = new List<InsertOwnerVariables>();

            foreach (InsertOwnerVariables ownerVariable in (InsertOwnerVariables[])Enum.GetValues(typeof(InsertOwnerVariables)))
            {
                ownerVariables.Add(ownerVariable);
            }

            while (ownerEmail == string.Empty
                   || ownerLastName == string.Empty
                   || ownerFirstName == string.Empty
                   || ownerPhone == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("Du skal tilføje følgende indformation:");
                int informationNumber = 1;
                foreach (InsertOwnerVariables ownerVariable in ownerVariables)
                {
                    Console.WriteLine(informationNumber + ". " + ownerVariable);
                    informationNumber++;
                }

                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > ownerVariables.Count)
                {
                    Console.WriteLine("Vælg venligst den information du vil indtaste.");
                }

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Indtast ejers efternavn:");
                        ownerLastName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Indtast ejers fornavn:");
                        ownerFirstName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Indtast ejers telefonnummer:");
                        ownerPhone = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Indtast ejers emailadresse:");
                        ownerEmail = Console.ReadLine();
                        break; 
                }

            }
            controller.AddOwner(ownerLastName, ownerFirstName, ownerPhone, ownerEmail);
        }

        private void ShowAllPets()
        {
            controller.ShowAllPets();
        }

        private void AddPet()
        {
            string petName = string.Empty;
            string petType = string.Empty;
            string petBreed = string.Empty;
            string petDateOfBirth = string.Empty;
            string petWeight = string.Empty;
            string ownerId = string.Empty;
            List<InsertPetVariables> petInformation = new List<InsertPetVariables>();

            foreach (InsertPetVariables petVariable in (InsertPetVariables[])Enum.GetValues(typeof(InsertPetVariables)))
            {
                petInformation.Add(petVariable);
            }

            while (petName == string.Empty 
                   || petType == string.Empty 
                   || petBreed == string.Empty 
                   || petDateOfBirth == string.Empty 
                   || petWeight == string.Empty
                   || ownerId == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("Du skal tilføje følgende indformation:");
                int informationNumber = 1;
                foreach (InsertPetVariables variables in petInformation)
                {
                    Console.WriteLine(informationNumber + ". " + variables);
                    informationNumber++;
                }

                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > petInformation.Count)
                {
                    Console.WriteLine("Vælg venligst den information du vil indtaste.");
                }

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Indtast kæledyrets navn:");
                        petName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Indtast kæledyrets type:");
                        petType = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Indtast kæledyrets rase:");
                        petBreed = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Indtast kæledyrets fødselsdag:");
                        petDateOfBirth = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Indtast kæledyrets vægt:");
                        petWeight = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Indtast kæledyrets ejer id:");
                        ownerId = Console.ReadLine();
                        break;
                }
            }
           controller.AddPet(petName, petType, petBreed, petDateOfBirth, petWeight, ownerId);
        }

        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }

        private void showMenu()
        {
            Console.Clear();
            Console.WriteLine("C# med Databaser:");
            Console.WriteLine();
            Console.WriteLine("1. Tilføj et kæledyr.");
            Console.WriteLine("2. Vis alle kæledyr.");
            Console.WriteLine("3. Tilføj en ejer.");
            Console.WriteLine("4. Find ejer med navn og email.");
            Console.WriteLine("5. Find ejer med efternavn.");
            Console.WriteLine("Tryk 0 for at afslutte.");
        }
    }
}
