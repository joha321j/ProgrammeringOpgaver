using System.Collections.Generic;

namespace DragonsLair
{
    public class Team
    {
        public string Name { get; set; }

        public Team(string teamName)
        {
            Name = teamName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
