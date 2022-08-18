using System;
using System.Collections.Generic;

namespace Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
          

            string command = Console.ReadLine();
            string password = string.Empty;
            

            while (command!="Done")
            {
                string[] tokans = command.Split(" ");
                string action = tokans[0];

                switch (action)
                {
                    case "TakeOdd":

                        for (int i = 1; i < input.Length; i+=2)
                        {
                            password += input[i];
                        }
                        input = password;
                       Console.WriteLine(input);
                        break;
                    case "Cut":
                        int index = int.Parse(tokans[1]);
                        int length = int.Parse(tokans[2]);
                        input = input.Remove(index, length);
                        Console.WriteLine(input);
                        break;
                    case "Substitute":
                        string substring = tokans[1];
                        string substitude = tokans[2];

                        if (input.Contains(substring))
                        {
                            input=input.Replace(substring, substitude);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {input}");
        }
    }
}
