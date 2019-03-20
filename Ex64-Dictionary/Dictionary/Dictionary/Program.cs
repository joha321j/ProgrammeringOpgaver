namespace Dictionary
{
    public enum MemberType
    {
        active, passive
    }
    class Program
    {
        static void Main(string[] args)
        {
            MemberUI ui = new MemberUI(new MemberController());
            ui.Run();
        }
    }
}
