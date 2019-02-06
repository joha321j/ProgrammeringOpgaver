namespace BadCode.Domain
{
    public class Match
    {
        private Team _winner;
        public Team FirstOpponent { get; set; }
        public Team SecondOpponent { get; set; }

        public Team Winner
        {
            get => _winner;
            set
            {
                if (string.Equals(value.ToString(), FirstOpponent.ToString()) ||
                    string.Equals(value.ToString(), SecondOpponent.ToString()))
                {
                    _winner = value;
                }
            }
        }

        public override string ToString()
        {
            return FirstOpponent + ";" + SecondOpponent;
        }
    }
}
