using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycles
{
    internal class Program
    {
        static void PrintFibNumbers(int n)
        {
            int[] fib = { 0, 1 };
            int prev1 = fib[0];
            int prev2 = fib[1];
            int current = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i > 2)
                {
                    current = prev1 + prev2;
                    prev1 = prev2;
                    prev2 = current;
                    Console.Write($"{current} ");
                }
                else if (i == 1)
                    Console.Write($"{prev1} ");
                else if (i == 2)
                    Console.Write($"{prev2} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            int n = 10;
            PrintFibNumbers(n);

            Console.Write("Task 2: ");
            int[] array = new int[21];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            for(int i = 1;i < array.Length; i++)
            {
                if (array[i] == 0) // Чтобы не выводить ноль, если элемент равен нулю
                    continue;

                if (array[i] % 2 == 0)
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Task 3");
            int[] array2 = new int[6];
            for (int i = 1; i < array2.Length; i++)
            {
                array2[i] = i;
            }
            Console.WriteLine("----------");
            for (int i = 1; i < array2.Length; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    Console.WriteLine($"{array2[i]} * {j} = {array2[i] * j}");
                }
                Console.WriteLine("----------");
            }
            
            Console.WriteLine("Task4");

            string password = "qwerty";
            string pass;
            do
            {
                Console.Write("Enter password: ");
                pass = Console.ReadLine();
                if (pass != password)
                {
                    PrintErrorMessage("Invalid password");
                }
                if (pass == password)
                {
                    PrintSuccessfulMessage("The password is correct");
                }
            }
            while (pass != "qwerty");

        }
        
        static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void PrintSuccessfulMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
