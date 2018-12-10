using System;

namespace ObserverPattern
{
    public class Student : IObserver
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

        public void Update()
        {
            Message = _subject.Message;
            Console.WriteLine("{0} modtog beskeden {1} fra {2}!", Name, Message, _subject.Name);
        }
    }
}