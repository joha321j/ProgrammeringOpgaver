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
        public event EventHandler RaisePetChangedEvent;
        public event EventHandler RaiseOwnerChangedEvent;
        private static Controller _instance;
        private readonly OwnerRepo _ownerRepo;
        private readonly PetRepo _petRepo;

        private Controller()
        {
            Connection connection = Connection.GetConnection();
            _ownerRepo = new OwnerRepo(connection);
            _petRepo = new PetRepo(connection);

            _petRepo.RaisePetRepoChangedEvent += PetRepo_RaisePetRepoChangedEvent;
            _ownerRepo.RaiseOwnerRepoChangeEvent += OwnerRepo_RaiseOwnerChangedEvent;
        }

        private void OwnerRepo_RaiseOwnerChangedEvent(object sender, OwnerEventArgs e)
        {
            UpdateOwnerSubscribers();
        }

        public void UnsubscribePetRepo()
        {
            _petRepo.RaisePetRepoChangedEvent -= PetRepo_RaisePetRepoChangedEvent;
        }

        private void PetRepo_RaisePetRepoChangedEvent(object sender, PetEventArgs eventArgs)
        {
            UpdatePetSubscribers();
        }

        public void UpdateOwnerSubscribers()
        {
            OnRaiseOwnerChangedEvent(EventArgs.Empty);
        }

        private void UpdatePetSubscribers()
        {
            OnRaisePetChangedEvent(EventArgs.Empty);
        }

        private void OnRaiseOwnerChangedEvent(EventArgs eventArgs)
        {
            EventHandler handler = RaiseOwnerChangedEvent;
            handler?.Invoke(this, eventArgs);
        }
        protected virtual void OnRaisePetChangedEvent(EventArgs eventArgs)
        {
            EventHandler handler = RaisePetChangedEvent;
            handler?.Invoke(this, eventArgs);
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

            _petRepo.AddPet(petName, petType, petBreed, petDateOfBirthDateTime.ToShortDateString(), petWeightDouble, ownerIdInt);
        }

        /// <summary>
        /// PetId, Name, Type, Breed, DateOfBirth, Weight, OwnerId
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllPets()
        {
            return _petRepo.GetAllPets();
        }

        public void AddOwner(string ownerLastName, string ownerFirstName, string ownerPhone, string ownerEmail)
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

        public void UpdatePet(string petId, string name, string type, string breed, string dob, string weight, string ownerId)
        {
            _petRepo.UpdatePet(petId, name, type, breed, dob, weight, ownerId);
        }

        public void DeletePet(string petId)
        {
            _petRepo.DeletePet(petId);
        }
    }
}
