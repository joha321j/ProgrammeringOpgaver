using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex32_linkedlist
{
    public class ClubMember
    {
        public int Number { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }

        public ClubMember(int number, string fName, string lName, int age)
        {
            Number = number;
            FName = fName;
            LName = lName;
            Age = age;
        }

        public override string ToString()
        {
            return Number + " " + FName + " " + LName + " " + Age;
        }
    }
}
