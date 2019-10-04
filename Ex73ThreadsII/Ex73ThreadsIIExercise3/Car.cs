namespace Ex73ThreadsIIExercise3
{
    class Car
    {
        public string Name { get; }

        public string Serial { get; }

        public Car(string name, string serial)
        {
            Name = name;
            Serial = serial;
        }

        public override string ToString()
        {
            return Name + " " + Serial;
        }
    }
}
