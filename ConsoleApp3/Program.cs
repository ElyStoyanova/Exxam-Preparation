using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "hjkll";
            char[] charArr = str.ToCharArray();
            Console.WriteLine(string.Join(",",charArr));
            List<char> sre = new List<char>();
            sre.AddRange(str);
            Console.WriteLine(string.Join(" ",sre));
            
        }
    }
}
