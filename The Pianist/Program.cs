using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pianist> pianists = new List<Pianist>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] pianistProperties = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                Pianist pianist = new Pianist()
                {
                    Piece = pianistProperties[0],
                    Composer=pianistProperties[1],
                    Key=pianistProperties[2]
                };
                pianists.Add(pianist);
            }

            string command = Console.ReadLine();

            while (command!="Stop")
            {
                string[] tokans = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string action = tokans[0];

                switch (action)
                {
                    case "Add":
                        AddMethod(tokans[1],tokans[2],tokans[3],pianists);
                        break;
                    case "Remove":
                        RemoveMethod(tokans[1],pianists);
                        break;
                    case "ChangeKey":
                        ChangeKeyMethod(tokans[1],tokans[2],pianists);
                        break;
                }

                command = Console.ReadLine();
            }
        }

         static void AddMethod(string piece, string composer, string key, List<Pianist> pianists)
        {
                Pianist pianist = new Pianist
                {
                     Piece = piece,
                     Composer = composer,
                     Key = key
                };
            
           
           if (pianists.Contains(pianist))
           {
               Console.WriteLine($"{piece} is already in the collection!");
               return;
            }
           pianists.Add(pianist);
           Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
        }

         static void RemoveMethod(string piece, List<Pianist> pianists)
        {
            
        }

         static void ChangeKeyMethod(string piece, string newKey, List<Pianist> pianists)
        {
            Pianist pianist = pianists.First(x => x.Piece == piece);
        }
    }
    class Pianist
    {
        public string Piece { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
