namespace ObserverPattern
{
    public class Student : Observer
    {
        private readonly Academy _subject;
        public string Message { get; set; }
        public string Name { get; }

        public Student(Academy subject, string name)
        {
            _subject = subject;
            Name = name;
            Update();
        }

        public sealed override void Update()
        {
            Message = _subject.Message;
        }
    }
}