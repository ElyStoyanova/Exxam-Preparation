using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = "Introduction in C# book";
            string word = "C#";
            int index = book.IndexOf(word);
            Console.WriteLine(index);
        }
    }
}
