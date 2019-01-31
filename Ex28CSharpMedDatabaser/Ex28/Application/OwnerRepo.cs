using System;
using System.Collections.Generic;
using Ex28.Domain;

namespace Ex28.Application
{
    class OwnerRepo
    {

        internal event EventHandler<OwnerEventArgs> RaiseOwnerRepoChangeEvent;
        private readonly List<Owner> _owners;
        private readonly Connection _connection;


        protected virtual void OnRaiseOwnerRepoChangeEvent(OwnerEventArgs eventArgs)
        {
            EventHandler<OwnerEventArgs> eventHandler = RaiseOwnerRepoChangeEvent;

            eventHandler?.Invoke(this, eventArgs);
        }

        private void NotifyDisplays(List<Owner> owners)
        {
            OnRaiseOwnerRepoChangeEvent(new OwnerEventArgs(owners));
        }
        internal OwnerRepo(Connection connection)
        {
            _connection = connection;
            _owners = GetAllOwners();
        }

        internal void AddOwner(string ownerFirstName, string ownerLastName, string ownerPhone, string ownerEmail)
        {
            Owner newOwner = new Owner(ownerFirstName, ownerLastName, ownerPhone, ownerEmail);

            _owners.Add(newOwner);
            _connection.AddOwner(newOwner);

            NotifyDisplays(_owners);
            
        }

        internal List<string> FindOwnerByEmail(string firstName, string email)
        {
            List<Owner> owners = _connection.FindOwnerByEmail(firstName, email);

            return owners.ConvertAll(obj => obj.ToString());
        }

        internal List<string> FindOwnerByLastName(string lastName)
        {
            List<Owner> owners = _connection.FindOwnerByLastName(lastName);

            return owners.ConvertAll(obj => obj.ToString());
        }

        private List<Owner> GetAllOwners()
        {
            return _connection.GetAllOwners();
        }
    }
}
