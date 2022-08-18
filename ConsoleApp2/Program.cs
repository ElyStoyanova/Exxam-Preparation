using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#\@])(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";
            string text = Console.ReadLine();
            var books = new Dictionary<string, string>();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            if (matches.Count>0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                foreach (Match match in matches)
                {
                    string word1 = match.Groups["word1"].Value;
                    string word2 = match.Groups["word2"].Value;
                    string olwWord2 = word2;
                       for (int i = word2.Length - 2; i >= 0; i--)
                       {
                          word2 += word2[i];
                          word2 = word2.Remove(i, 1);
                       }

                    
                    if (word1.Equals(word2))
                    { 
                        books.Add(word1, olwWord2);
                    }
                 
                }    
            }
            else
            {
                Console.WriteLine("No word pairs found!");
               
            }
            if (books.Count != 0)
            {
                Console.WriteLine("The mirror words are:");

                // books.Select(i => $"{i.Key} <=> {i.Value}, ").ToList().ForEach(Console.Write);
                int i = 1;
               
                foreach (var book in books)
                {
                        Console.Write(i<books.Count ? $"{book.Key} <=> {book.Value}, " : $"{book.Key} <=> {book.Value}");
                    i++;
                }
            }   
            
            if (books.Count==0)
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
