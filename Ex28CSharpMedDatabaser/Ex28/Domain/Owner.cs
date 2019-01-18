namespace Ex28.Domain
{
    internal class Owner
    {
        internal string FirstName { get; }
        internal string LastName { get; }
        internal string Phone { get; }
        internal string Email { get; }
        internal int Id { get; }

        public Owner(string firstName, string lastName, string phone, string email = "NULL", int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Id = id;
        }

        public override string ToString()
        {
            return "OwnerID: " + Id + " OwnerLastName: " + LastName + " OwnerFirstName: " + FirstName +
                   " OwnerPhone: " + Phone + " OwnerEmail: " + Email;
        }
    }
}