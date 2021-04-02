using System;

namespace Challenge1pt1
{
    class Program {

        static void Main(string[] args) { 

            int distance;
            double fuel, average_fuel_consumption;

            Console.WriteLine("Travelled distance: ");
            distance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Spent fuel: ");
            fuel = Convert.ToDouble(Console.ReadLine());

            average_fuel_consumption = distance/fuel;

            Console.WriteLine("{0:0.000} km/l", average_fuel_consumption);
        }
    }
}
