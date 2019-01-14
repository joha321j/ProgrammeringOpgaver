using System;

namespace ArchitectureUsingEvent
{
    public class MLength
    {
        public event EventHandler<CustomArgs> MessageSetLengthEvent;

        private string _messageLength;
        public string MessageLength { get => _messageLength;
            set
            {
                CustomArgs customArgs = new CustomArgs(_messageLength, value);

                _messageLength = value;

                MessageSetLengthEvent?.Invoke(this, customArgs);

            }

        }

        public MLength(IMessage message)
        {
            MessageLength = message.MyMessage.Length.ToString();
        }
    }
}
