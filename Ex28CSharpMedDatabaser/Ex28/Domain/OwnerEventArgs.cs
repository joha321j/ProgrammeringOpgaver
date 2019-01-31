using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28.Domain
{
    class OwnerEventArgs
    {
        public List<Owner> Owners { get; set; }

        public OwnerEventArgs(List<Owner> owners)
        {
            Owners = owners;
        }
    }
}
