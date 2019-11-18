using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HashingExercise
{
    class Program
    {
        private const int MaxHashValue = 99;

        private const int HashValueLength = 2;

        static void Main(string[] args)
        {
            Program prog = new Program();

            prog.Run();

        }

        private void Run()

        {

            bool running = true;

            Console.WriteLine("Enter a password and get the hashed value.");

            while (running)

            {

                Console.Write("Enter password ('q' to end) : ");

                string answer = Console.ReadLine();

                if (answer != null && answer.Equals("q"))

                {

                    running = false;

                    Console.WriteLine("Bye");

                }

                else

                {

                    Console.WriteLine(PadZero(GetHashValue(answer), HashValueLength));
                    Console.WriteLine(PadZero(GetHashValueOg(answer), HashValueLength));

                }

            }

        }

        public string PadZero(int value, int length)

        {

            string result = value.ToString();

            for (int idx = 0; result.Length < HashValueLength; idx++)

            {

                result = "0" + result;

            }

            return result;

        }

        public int GetHashValue(string password)

        {

            int result = 0;

            foreach (char t in password)
            {
                result += Convert.ToInt16(t);
            }

            return result % (MaxHashValue + 1);

        }

        public int GetHashValueOg(string password)
        {
            int[] asciiArray = password.Select(r => (int)r).ToArray();

            int modifier = asciiArray[0];
            double modifier2 = asciiArray[^1] * 11 / 5;

            double hashedValue = modifier * asciiArray.Sum() + modifier2;
            hashedValue = hashedValue % MaxHashValue+1;

            return (int) hashedValue;
        }

        public byte[] Scrypt(string stringToHash, string salt, int costFactor, int blockSizeFactor, int parallelizationFactor, int desiredKeyLength)
        {
            int blockSize = 128 * blockSizeFactor;

            // Use PBKDF2 to generate initial 128*BlockSizeFactor*p bytes of data (e.g. 128*8*3 = 3072 bytes)
            // Treat the result as an array of p elements, each entry being blocksize bytes(e.g. 3 elements, each 1024 bytes)

            SHA256 Hasher = SHA256.Create();

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(Encoding.ASCII.GetBytes(stringToHash), Encoding.ASCII.GetBytes(salt), 1);

        }
    }

}

