using System;
using System.Text;

namespace NumberOfWordsCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder("This is to test whether the extension method count can return a right answer or not");
            Console.WriteLine("Number of words in '" + stringBuilder + "' is " + countNumberOfWords(stringBuilder)+".");
        }

        public static int countNumberOfWords(StringBuilder stringBuilder)
        {
            return stringBuilder.ToString().Split(' ').Length;
        }
    }
}

