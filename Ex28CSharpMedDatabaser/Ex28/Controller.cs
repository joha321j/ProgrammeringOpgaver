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
        private readonly Connection _connection = new Connection();

        public void AddPet(string petName, string petType, string petBreed, string petDateOfBirth, string petWeight, string ownerId)
        {
            int.TryParse(ownerId, out int ownerIdInt);
            double.TryParse(petWeight, out double petWeightDouble);
            DateTime petDateOfBirthDateTime = Convert.ToDateTime(petDateOfBirth);

            _connection.AddPet(petName, petType, petBreed, petDateOfBirthDateTime, petWeightDouble, ownerIdInt);
        }

        public List<string> GetAllPets()
        {
            return _connection.GetAllPets();
        }

        public void AddOwner(string ownerLastName, string ownerFirstName, string ownerPhone, string ownerEmail)
        {
            _connection.AddOwner(ownerFirstName, ownerLastName, ownerPhone, ownerEmail);
        }

        public List<string> FindOwnerByEmail(string firstName, string email)
        {
            return _connection.FindOwnerByEmail(firstName, email);
        }

        public List<string> FindOwnerByLastName(string lastName)
        {
            return _connection.FindOwnerByLastName(lastName);
        }
    }
}
