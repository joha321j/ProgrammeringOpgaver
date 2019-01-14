using System;

namespace ArchitectureUsingEvent
{
    public class Worker
    {
        private readonly IScreen _screen;
        private readonly IMessage _message;
        private readonly MLength _mLength;

        public Worker(IScreen screen, IMessage message, MLength mLength)
        {
            _screen = screen;
            _message = message;
            _mLength = mLength;
        }

        public void ReverseTextValue()
        {
            char[] arr = _screen.TextValue.ToCharArray();
            Array.Reverse(arr);
            _message.MyMessage = new string(arr);
        }

        public void SetTextValue()
        {
            _mLength.MessageLength = _screen.Answer.Length.ToString();
            _message.MyMessage = _screen.Answer;

        }
    }
}
