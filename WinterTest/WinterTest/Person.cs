using System;

namespace WinterTest
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;

        public Person(string firstName = "", string lastName = "")
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}