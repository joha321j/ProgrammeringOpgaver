﻿namespace BadCode.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        
        public Player(string playerName, string playerAddress = null, string playerEmail = null, string playerTelephone = null)
        {
            Name = playerName;
            Address = playerAddress;
            Email = playerEmail;
            TelephoneNumber = playerTelephone;
        }
    }
}
