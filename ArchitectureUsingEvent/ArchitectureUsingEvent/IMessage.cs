using System;

namespace ArchitectureUsingEvent
{
    public interface IMessage
    {
        event EventHandler<CustomArgs> MessageSetEvent;
        string MyMessage { get; set; }
    }
}
