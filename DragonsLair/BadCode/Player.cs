namespace BadCode
{
    public class Player
    {
        public string n { get; set; }
        public string a { get; set; }
        public string em { get; set; }
        public string t { get; set; }
        
        public Player(string playerName, string playerAddress = null, string playerEmail = null, string playerTelephone = null)
        {
            n = playerName;
            a = playerAddress;
            em = playerEmail;
            t = playerTelephone;
        }
    }
}
