using System;
using System.Text.RegularExpressions;

namespace Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string pattern = @"([#|])(?<itemName>[A-Za-z\s]+)\1(?<day>[0-9]{2})\/(?<month>[0-9]{2})\/(?<year>[0-9]{2})\1(?<calories>[0-9]{1,5})\1";
            int sumCalories = 0;

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(inputString);

            foreach (Match match in matches)
            {
                sumCalories += int.Parse(match.Groups["calories"].Value);
            }

            int restDays = sumCalories / 2_000;

            Console.WriteLine($"You have food to last you for: {restDays} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["itemName"]}, Best before: {match.Groups["day"]}/{match.Groups["month"]}/{match.Groups["year"]}, Nutrition: {match.Groups["calories"]}");
            }
            

        }
    }
}
