using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28.Domain
{
    class DomainFacade
    {
        private readonly OwnerController _ownerController;
        private readonly PetController _petController;

        public DomainFacade()
        {
            var connection = new Connection();
            _petController = new PetController(connection);
            _ownerController = new OwnerController(connection);
        }

        public void AddPet(string petName, string petType, string petBreed, string toShortDateString, double petWeightDouble, int ownerIdInt)
        {
            _petController.AddPet(petName, petType, petBreed, toShortDateString, petWeightDouble, ownerIdInt);
        }

        public List<string> GetAllPets()
        {
            return _petController.GetAllPets();
        }

        public void AddOwner(string ownerFirstName, string ownerLastName, string ownerPhone, string ownerEmail)
        {
            _ownerController.AddOwner(ownerFirstName, ownerLastName, ownerPhone, ownerEmail);
        }

        public List<string> FindOwnerByEmail(string firstName, string email)
        {
            return _ownerController.FindOwnerByEmail(firstName, email);
        }

        public List<string> FindOwnerByLastName(string lastName)
        {
            return _ownerController.FindOwnerByLastName(lastName);
        }
    }
}
