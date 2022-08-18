using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes_of_Code_and_Logic_VII_with_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heros = new List<Hero>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] heroPropeties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Hero hero = new Hero
                {
                    Name = heroPropeties[0],
                    HitPoits = int.Parse(heroPropeties[1]),
                    ManaPoints=int.Parse(heroPropeties[2])
                };
                heros.Add(hero);
            }
            string input = Console.ReadLine();

            while (input!="End")
            {
                string[] tokans = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokans[0];

                switch (command)
                {
                    case "CastSpell":
                        CastSpell(tokans[1],int.Parse(tokans[2]),tokans[3],heros);
                        break;
                    case "TakeDamage":
                        TakeDamage(tokans[1],int.Parse(tokans[2]),tokans[3],heros);
                        break;
                    case "Recharge":
                        Recharge(tokans[1], int.Parse(tokans[2]), heros);
                        break;
                    case "Heal":
                        Heal(tokans[1],int.Parse(tokans[2]),heros);
                        break;
                }


                input = Console.ReadLine();
            }
            foreach (Hero hero in heros)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"  HP: {hero.HitPoits}");
                Console.WriteLine($"  MP: {hero.ManaPoints}");
            }  
        }

        static void CastSpell(string name, int manaNeeded, string spell, List<Hero> heros)
        {
            Hero hero = heros.First(h => h.Name == name);

            if (hero.ManaPoints>=manaNeeded)
            {
                hero.ManaPoints -= manaNeeded;

                Console.WriteLine($"{name} has successfully cast {spell} and now has {hero.ManaPoints} MP!");
                return;
            }
            Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
        }

         static void TakeDamage(string name, int damege, string attacker, List<Hero> heros)
        {
            Hero hero = heros.First(h => h.Name == name);

            hero.HitPoits -= damege;

            if (hero.HitPoits>0)
            {
                Console.WriteLine($"{name} was hit for {damege} HP by {attacker} and now has {hero.HitPoits} HP left!");
                return;
            }
            Console.WriteLine($"{name} has been killed by {attacker}!");

            heros.Remove(hero);
        }

         static void Recharge(string name, int mana, List<Hero> heros)
        {
            Hero hero = heros.First(h => h.Name == name);

            int originalMana = hero.ManaPoints;
            hero.ManaPoints += mana;

            if (hero.ManaPoints>200)
            {
                hero.ManaPoints = 200;
            }
            Console.WriteLine($"{name} recharged for {hero.ManaPoints-originalMana} MP!");
        }

         static void Heal(string name, int healPoints, List<Hero> heros)
        {
            Hero hero = heros.First(h => h.Name == name);

            int originalHitPoints = hero.HitPoits;
            hero.HitPoits += healPoints;

            if (hero.HitPoits>100)
            {
                hero.HitPoits = 100;
            }
            Console.WriteLine($"{name} healed for {hero.HitPoits-originalHitPoints} HP!");
        }
    }
    class Hero
    {
        public string Name { get; set; }
        public int HitPoits { get; set; }
        public int ManaPoints { get; set; }
    }

}
