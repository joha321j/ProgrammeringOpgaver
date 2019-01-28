using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ex28.Domain;

namespace Ex28.Application
{
    public class Controller
    {
        private static Controller _instance;
        private readonly DomainFacade _domain;

        private Controller()
        {
            _domain = new DomainFacade();
        }

        public static Controller GetController()
        {
            return _instance ?? (_instance = new Controller());
        }

        public void AddPet(string petName, string petType, string petBreed, string petDateOfBirth, string petWeight, string ownerId)
        {
            int.TryParse(ownerId, out int ownerIdInt);
            double.TryParse(petWeight, out double petWeightDouble);
            DateTime petDateOfBirthDateTime = Convert.ToDateTime(petDateOfBirth);

            _domain.AddPet(petName, petType, petBreed, petDateOfBirthDateTime.ToShortDateString(), petWeightDouble, ownerIdInt);
        }

        /// <summary>
        /// PetId, Name, Type, Breed, DateOfBirth, Weight, OwnerId
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllPets()
        {
            return _domain.GetAllPets();
        }

        public void AddOwner(string ownerLastName, string ownerFirstName, string ownerPhone, string ownerEmail)
        {
            _domain.AddOwner(ownerFirstName, ownerLastName, ownerPhone, ownerEmail);
        }

        public List<string> FindOwnerByEmail(string firstName, string email)
        {
            return _domain.FindOwnerByEmail(firstName, email);
        }

        public List<string> FindOwnerByLastName(string lastName)
        {
            return _domain.FindOwnerByLastName(lastName);
        }
    }
}
