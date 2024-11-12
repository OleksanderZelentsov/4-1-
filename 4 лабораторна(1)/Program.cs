using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_лабораторна_1_
{
    class Program
    {
        static List<int> DecomposeIntoOddPowersOfTwo(int N)
        {
            List<int> result = new List<int>();
            int power = 0;
            while ((int)Math.Pow(2, power) <= N)
            {
                power += 1; 
                if(power%2==0)
                    power += 1;
                if (power < 0)
                    power += 1;
            }
            power -= 1;
            if (power % 2 == 0)
                power -= 1;
            while (N > 0)
            {
                int oddPower = (int)Math.Pow(2, power); 
                if (oddPower <= N)
                {
                    result.Add(oddPower);  
                    N -= oddPower;         
                }
                else if (oddPower > N)
                {
                    power -= 1;
                    if (power % 2 == 0)
                        power -= 1;
                    if(power<0)
                        power += 1;
                }
            }
            return result;
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Розкласти число на непарні ступені двійки");
                Console.WriteLine("2. Вийти з програми");
                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Введіть число, яке треба розкласти: ");
                        if (int.TryParse(Console.ReadLine(), out int N) && N > 0)
                        {
                            List<int> decomposition = DecomposeIntoOddPowersOfTwo(N);
                            Console.WriteLine("Розклад числа на непарні ступені двійки:");
                            foreach (int term in decomposition)
                            {
                                Console.WriteLine(term);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Будь ласка, введіть коректне натуральне число.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Вихід з програми...");
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}