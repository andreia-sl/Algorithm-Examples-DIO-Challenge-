using System;

namespace Challenge1pt3
{
    class Program
    {
        static void Main(string[] args) { 
            double salary = 0.00;
            double incrase_rate = 0.00;
            double newWage = 0.00;
            double percentual = 0.00;

            try
            {
                salary = Convert.ToDouble(Console.ReadLine().Replace(",","."));
            }
            catch
            {
            return;
            }
            
            if(salary < 0.00) {
                return;
            } 
            else if (salary <= 400.00) {
                percentual = 0.15;
                incrase_rate = salary * percentual;
                newWage = salary + incrase_rate;
            } else if (salary <= 800.00) {
                percentual = 0.12;
                incrase_rate = salary * percentual;
                newWage = salary + incrase_rate;
            } else if (salary <= 1200.00) {
                percentual = 0.10;
                incrase_rate = salary * percentual;
                newWage = salary + incrase_rate;
            } else if (salary <= 2000.00) {
                percentual = 0.07;
                incrase_rate = salary * percentual;
                newWage = salary + incrase_rate;
            } else {
                percentual = 0.04;
                incrase_rate = salary * percentual;
                newWage = salary + incrase_rate;
            }
            
            Console.WriteLine("New salary amount: {0:0.00}", newWage);
            Console.WriteLine("Incrase rate: {0:0.00}", incrase_rate);
            Console.WriteLine("Percentual: {0} %", percentual * 100.00);
        }
    }
}