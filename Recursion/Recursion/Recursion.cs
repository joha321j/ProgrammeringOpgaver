using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recursion
{
    public static class Recursion
    {
        public static int Faculty(int i)
        {
            if (i == 1)
            {
                return 1;
            }

            if (i == 0)
            {
                return 0;
            }
            return i == 2 ? 2 : i * Faculty(i - 1);
        }

        public static int Fibonacci(int i)
        {
            switch (i)
            {
                case 1:
                    return 1;
                case 0:
                    return 0;
                default:
                    return Fibonacci(i - 1) + Fibonacci(i - 2);
            }
        }

        public static bool IsPalindrome(string text)
        {
            text = text.Trim(' ');

            if (text.Length <= 1)
            {
                return true;
            }

            if (text[0] == text[text.Length-1])
            {
                return IsPalindrome(text.Substring(1, text.Length - 2));
            }

            return false;
        }

        public static void TowersOfHanoi()
        {
            List<int> aInts = new List<int>();
            aInts.Add(6);
            aInts.Add(5);
            aInts.Add(4);
            aInts.Add(3);
            aInts.Add(2);
            aInts.Add(1);

            List<int> bInts = new List<int>();
            List<int> cInts = new List<int>();

            Move(6, aInts, bInts, cInts);
        }

        private static void Move(int n, List<int> source, List<int> target, List<int> auxiliary)
        {
            if (n > 0)
            {
                Move(n - 1, source, auxiliary, target);

                target.Add(source[source.Count - 1]);
                source.RemoveAt(source.Count - 1);


                foreach (int i in source)
                {
                    Console.Write(i + "; ");
                }

                Console.WriteLine();

                foreach (int i in target)
                {
                    Console.Write(i + "; ");
                }

                Console.WriteLine();

                foreach (int i in auxiliary)
                {
                    Console.WriteLine(i + "; ");
                }

                Move(n - 1, auxiliary, target, source);
            }
        }
    }
}
