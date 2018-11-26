using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex28
{
    class Controller
    {
        Database database = new Database();

        public void AddPet(string petName, string petType, string petBreed, string petDateOfBirth, string petWeight, string ownerId)
        {
            int.TryParse(ownerId, out int ownerIdInt);
            double.TryParse(petWeight, out double petWeightDouble);
            DateTime petDateOfBirthDateTime = Convert.ToDateTime(petDateOfBirth);

            database.AddPet(petName, petType, petBreed, petDateOfBirthDateTime, petWeightDouble, ownerIdInt);
        }

        public void ShowAllPets()
        {
            database.ShowAllPets();
        }

        public void AddOwner(string ownerLastName, string ownerFirstName, string ownerPhone, string ownerEmail)
        {
            database.AddOwner(ownerFirstName, ownerLastName, ownerPhone, ownerEmail);
        }

        public void FindOwnerByEmail(string firstName, string email)
        {
            database.FindOwnerByEmail(firstName, email);
        }

        public void FindOwnerByLastName(string lastName)
        {
            database.FindOwnerByLastName(lastName);
        }
    }
}
