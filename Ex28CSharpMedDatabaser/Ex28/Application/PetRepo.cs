using System;
using System.Collections.Generic;
using System.Linq;
using Ex28.Domain;

namespace Ex28.Application
{
    internal class PetRepo
    {
        public event EventHandler<PetEventArgs> RaisePetRepoChangedEvent; 
        private List<Pet> _pets;
        private readonly Connection _connection;

        protected virtual void OnRaisePetRepoChangedEvent(PetEventArgs eventArgs)
        {
            EventHandler<PetEventArgs> handler = RaisePetRepoChangedEvent;

            handler?.Invoke(this, eventArgs);
        }

        private void NotifySubscribers()
        {
            OnRaisePetRepoChangedEvent(new PetEventArgs(_pets));
        }

        public PetRepo(Connection connection)
        {
            _connection = connection;
            _pets = _connection.GetAllPets();
        }

        public void AddPet(string petName, string petType, string petBreed, string petDateOfBirthDateTime, double petWeightDouble, int ownerIdInt)
        {
            Pet pet = new Pet(petName, petType, petBreed, petDateOfBirthDateTime, petWeightDouble, ownerIdInt);

            _pets.Add(pet);
            _connection.AddPet(pet);

            NotifySubscribers();
        }

        public List<string> GetAllPets()
        { 
            List<string> stringList = _pets.ConvertAll(pet => pet.ToString());
            return stringList;
        }


        public void UpdatePet(string petId, string name, string type, string breed, string dob, string weight, string ownerId)
        {
            int tempId = int.Parse(petId);
            Pet tempPet = new Pet(name, type, breed, dob, double.Parse(weight), int.Parse(ownerId), tempId);

            Pet petToRemove = _pets.Find(pet => pet.PetId == tempId);

            _pets.Remove(petToRemove);
            _pets.Add(tempPet);
            _pets = _pets.OrderBy(pet => pet.PetId).ToList();

            NotifySubscribers();
        }

        public void DeletePet(string petId)
        {
            int tempId = int.Parse(petId);

            Pet petToDelete = _pets.Find(pet => pet.PetId == tempId);

            _pets.Remove(petToDelete);

            NotifySubscribers();
        }
    }
}
