using System;

namespace Sicret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string key = Console.ReadLine();

            while (key!= "Generate")
            {
                string[] tokans = key.Split(">>>");
                string command = tokans[0];

                switch (command)
                {
                    case "Contains":
                        string substring = tokans[1];

                        if (input.Contains(substring))
                        {
                            Console.WriteLine($"{input} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string casing = tokans[1];
                        int startIndex = int.Parse(tokans[2]);
                        int endIndex = int.Parse(tokans[3]);
                        string originalSubtring = input.Substring(startIndex, endIndex - startIndex);
                        string newSubstring = originalSubtring.ToLower();

                        if (casing=="Upper")
                        {
                            newSubstring = originalSubtring.ToUpper();
                        }
                        input = input.Replace(originalSubtring, newSubstring);
                        Console.WriteLine(input);
                        break;
                    case "Slice":
                        int startIndexSlice = int.Parse(tokans[1]);
                        int endIndexSlice = int.Parse(tokans[2]);
                        input = input.Remove(startIndexSlice,endIndexSlice-startIndexSlice);
                        Console.WriteLine(input);
                        break;
                }

                key = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
