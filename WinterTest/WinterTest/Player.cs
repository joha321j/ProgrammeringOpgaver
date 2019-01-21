using System.Collections.Generic;

namespace WinterTest
{
    public class Player : Person
    {
        private readonly List<int> _scores = new List<int>();
        public Player(string firstName, string lastName) : base(firstName, lastName)
        {

        }

        public void RegisterScore(int noOfGuesses)
        {
            _scores.Add(noOfGuesses);
        }

        public bool HasScoreOfOne()
        {
            return _scores.Exists(score => score == 1);
        }
    }
}