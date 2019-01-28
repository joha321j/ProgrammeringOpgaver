using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28.Domain
{
    public class Pet
    {
        internal int PetId { get; }
        internal string Name { get; }
        internal string Type { get; }
        internal string Breed { get; }
        internal string DateOfBirth { get; }
        internal double Weight { get; }
        internal int OwnerId { get; }

        public Pet(string name, string type, string breed, string dateOfBirth, double weight, int ownerId,
            int petId = 0)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Breed = breed ?? throw new ArgumentNullException(nameof(breed));
            DateOfBirth = dateOfBirth ?? throw new ArgumentNullException(nameof(dateOfBirth));
            Weight = weight;
            OwnerId = ownerId;
            PetId = petId;

        }
       
        /// <summary>
        /// PetId, Name, Type, Breed, DateOfBirth, Weight, OwnerId
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PetId + ", " + Name + ", " + Type + ", " + Breed + ", " +
                   DateOfBirth + ", " + Weight + ", " + OwnerId;
        }
    }
}
