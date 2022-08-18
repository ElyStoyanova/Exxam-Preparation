using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pianists = new Dictionary<string, KeyValuePair<string,string>>();
            var order = new List<string>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] pianistProperties = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = pianistProperties[0];
                string composer = pianistProperties[1];
                string key = pianistProperties[2];

                pianists.Add(piece, new KeyValuePair<string, string>( composer, key ));
                order.Add(piece);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] tokans = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string action = tokans[0];
                

                switch (action)
                {
                    case "Add":
                        AddMethod(tokans[1], tokans[2], tokans[3], pianists,order);
                        break;
                    case "Remove":
                        RemoveMethod(tokans[1], pianists,order);
                        break;
                    case "ChangeKey":
                        ChangeKeyMethod(tokans[1], tokans[2], pianists);
                        break;
                }

                command = Console.ReadLine();
            }
            foreach (var piece in order)
            {
                
                Console.WriteLine($"{piece} -> Composer: {pianists[piece].Key}, Key: {pianists[piece].Value}");
            }
        }

         static void AddMethod(string piece, string composer, string key, Dictionary<string, KeyValuePair<string, string>> pianists, List<string> order)
        {
            if (!pianists.ContainsKey(piece))
            {
                pianists.Add(piece, new KeyValuePair<string, string>(composer, key));
                order.Add(piece);
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                return;
            }
            Console.WriteLine($"{piece} is already in the collection!");
        }

        static void RemoveMethod(string piece, Dictionary<string, KeyValuePair<string, string>> pianists, List<string> order)
        {
            if (pianists.ContainsKey(piece))
            {
                pianists.Remove(piece);
                order.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");
                return;
            }
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }

        static void ChangeKeyMethod(string piece, string newKey, Dictionary<string, KeyValuePair<string, string>> pianists)
        {
            if (pianists.ContainsKey(piece))
            {
                var composer = pianists[piece].Key;
                pianists[piece] = new KeyValuePair<string, string>(composer, newKey);
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                return ;
            }
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }
    }
}
