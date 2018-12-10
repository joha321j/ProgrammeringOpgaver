namespace ObserverPattern
{
    public class Academy : Subject
    {
        private string _message;
        public string Name { get; }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                Notify();
            }
        }

        public Academy(string name)
        {
            Name = name;
        }
    }
}