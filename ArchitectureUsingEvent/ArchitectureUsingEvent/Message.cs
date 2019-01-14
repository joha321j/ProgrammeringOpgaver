using System;

namespace ArchitectureUsingEvent
{
    public class Message : IMessage
    {
        public event EventHandler<CustomArgs> MessageSetEvent;
        private string _myMessage;

        public string MyMessage {
            get => _myMessage;
            set {
				//should change myMessage and raise the MessageSetEvent
				//To do that we need an CustomArgs instance holding the
				//old (before) and new (after) value of myMessage 

                CustomArgs customArgs = new CustomArgs(_myMessage, value);

                _myMessage = value;

                MessageSetEvent?.Invoke(this, customArgs);
            }
        }

        public Message()
        {
            _myMessage = "No message";
        }
    }
}
