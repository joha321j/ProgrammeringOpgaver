using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28.Domain
{
    internal class PetController
    {
        private readonly Connection _connection;

        public PetController(Connection connection)
        {
            _connection = connection;
        }

        public void AddPet(string petName, string petType, string petBreed, string petDateOfBirthDateTime, double petWeightDouble, int ownerIdInt)
        {
            _connection.AddPet(new Pet(petName, petType, petBreed, petDateOfBirthDateTime, petWeightDouble, ownerIdInt));
        }

        public List<string> GetAllPets()
        {
            List<Pet> allPets = _connection.GetAllPets();

            List<string> strings = allPets.ConvertAll(obj => obj.ToString());

            return strings;
        }
    }
}
