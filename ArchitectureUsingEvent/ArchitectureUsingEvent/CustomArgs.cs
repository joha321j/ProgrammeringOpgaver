using System;

namespace ArchitectureUsingEvent
{
    public class CustomArgs : EventArgs
    {
		//implement as described in the class diagram
		
        public CustomArgs(string before, string after)
        {
            MessageBefore = before;
            MessageAfter = after;
        }

        public string MessageAfter { get; }
        public string MessageBefore { get; }
    }
}
