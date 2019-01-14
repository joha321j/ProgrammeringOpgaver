namespace ArchitectureUsingEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            Message message = new Message();
            MLength mLength = new MLength(message);
            Screen screen = new Screen(message, mLength);
            screen.ShowScreen();
        }
    }
}
