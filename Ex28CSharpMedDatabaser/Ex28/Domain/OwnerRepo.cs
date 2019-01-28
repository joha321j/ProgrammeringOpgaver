using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28.Domain
{
    class OwnerRepo
    {
        private readonly Connection _connection;

        public OwnerRepo(Connection connection)
        {
            _connection = connection;
        }

        public void AddOwner(string ownerFirstName, string ownerLastName, string ownerPhone, string ownerEmail)
        {
            Owner newOwner = new Owner(ownerFirstName, ownerLastName, ownerPhone, ownerEmail);

            _connection.AddOwner(newOwner);
            
        }

        public List<string> FindOwnerByEmail(string firstName, string email)
        {
            List<Owner> owners = _connection.FindOwnerByEmail(firstName, email);

            return owners.ConvertAll(obj => obj.ToString());
        }

        public List<string> FindOwnerByLastName(string lastName)
        {
            List<Owner> owners = _connection.FindOwnerByLastName(lastName);

            return owners.ConvertAll(obj => obj.ToString());
        }
    }
}
