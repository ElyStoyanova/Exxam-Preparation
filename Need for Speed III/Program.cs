using System;
using System.Collections.Generic;
using System.Linq;

namespace Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] carProparties = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car
                {
                    Brand = carProparties[0],
                    Miliage = int.Parse(carProparties[1]),
                    Fuel = int.Parse(carProparties[2])
                };
                cars.Add(car);
            }
            string commands = Console.ReadLine();

            while (commands!="Stop")
            {
                string[] tokans = commands.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokans[0];

                switch (action)
                {
                    case "Drive":
                        DriveMethod(tokans[1], int.Parse(tokans[2]), int.Parse(tokans[3]),cars);
                        break;
                    case "Refuel":
                        RefuelMethod(tokans[1],int.Parse(tokans[2]),cars);
                        break;
                    case "Revert":
                        RevertMethod(tokans[1],int.Parse(tokans[2]),cars);
                        break;

                }

                commands = Console.ReadLine();
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Brand} -> Mileage: {car.Miliage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }

        static void DriveMethod(string brand, int distans, int fuel, List<Car> cars)
        {
            Car car = cars.First(x => x.Brand == brand);

            if (car.Fuel<fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }
            car.Miliage += distans;
            car.Fuel -= fuel;
            Console.WriteLine($"{brand} driven for {distans} kilometers. {fuel} liters of fuel consumed.");

            if (car.Miliage>=100_000)
            {
                Console.WriteLine($"Time to sell the {brand}!");
                cars.Remove(car);
            }
        }

        static void RefuelMethod(string brand, int fuel, List<Car> cars)
        {
            Car car = cars.First(x => x.Brand == brand);

            int oldFuel = car.Fuel;
            car.Fuel += fuel;

            if (car.Fuel>75)
            {
                car.Fuel = 75;
            }
            Console.WriteLine($"{brand} refueled with {car.Fuel-oldFuel} liters");     
        }

        static void RevertMethod(string brand, int kilometers, List<Car> cars)
        {
            Car car = cars.First(x=>x.Brand==brand);

            car.Miliage -= kilometers;
            Console.WriteLine($"{brand} mileage decreased by {kilometers} kilometers");

            if (car.Miliage<10_000)
            {
                car.Miliage = 10_000;
            }
        }
    }
    public class Car
    {
        public string Brand { get; set; }
        public int Miliage { get; set; }
        public int Fuel { get; set; }
    }              
}
