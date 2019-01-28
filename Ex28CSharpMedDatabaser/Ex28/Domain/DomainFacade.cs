using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28.Domain
{
    class DomainFacade
    {
        private readonly OwnerRepo _ownerRepo;
        private readonly PetRepo _petRepo;

        public DomainFacade()
        {
            var connection = new Connection();
            _petRepo = new PetRepo(connection);
            _ownerRepo = new OwnerRepo(connection);
        }

        public void AddPet(string petName, string petType, string petBreed, string toShortDateString, double petWeightDouble, int ownerIdInt)
        {
            _petRepo.AddPet(petName, petType, petBreed, toShortDateString, petWeightDouble, ownerIdInt);
        }

        public List<string> GetAllPets()
        {
            return _petRepo.GetAllPets();
        }

        public void AddOwner(string ownerFirstName, string ownerLastName, string ownerPhone, string ownerEmail)
        {
            _ownerRepo.AddOwner(ownerFirstName, ownerLastName, ownerPhone, ownerEmail);
        }

        public List<string> FindOwnerByEmail(string firstName, string email)
        {
            return _ownerRepo.FindOwnerByEmail(firstName, email);
        }

        public List<string> FindOwnerByLastName(string lastName)
        {
            return _ownerRepo.FindOwnerByLastName(lastName);
        }
    }
}
