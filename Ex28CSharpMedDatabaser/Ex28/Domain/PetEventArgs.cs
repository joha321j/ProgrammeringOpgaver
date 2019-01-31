    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28.Domain
{
    class PetEventArgs : EventArgs
    {
        public List<Pet> Data { get; set; }

        public PetEventArgs(List<Pet> pet)
        {
            Data = pet;
        }
    }
}
