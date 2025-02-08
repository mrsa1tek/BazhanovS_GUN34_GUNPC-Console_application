using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
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
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task A");
            Console.WriteLine("Task 1");
            // Здесь массивы заданий 1-4
            int n = 8;
            PrintFibNumbers(n);
            PrintSpace();
            PrintSpace();

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


            Console.WriteLine("Task 3");
            int m = 3;
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int number = j + 2;
                    int exp = i + 1;

                    matrix[i, j] = (int)Math.Pow(number, exp);
                    Console.Write(matrix[i, j] + "\t");
                }
                PrintSpace();
            }
            PrintSpace();

            Console.WriteLine("Task 4");
            double[][] arrayA = new double[4][];
            arrayA[0] = new double[5];
            arrayA[1] = new double[2];
            arrayA[2] = new double[5];

            Console.Write("First array:\t");
            for (int i = 0; i < 5; i++)
            {
                arrayA[0][i] = i+1;
                Console.Write(arrayA[0][i] + "\t");
            }
            PrintSpace();

            Console.WriteLine($"Second array: {arrayA[1][0] = Math.E} {arrayA[1][1] = Math.PI}");

            arrayA[2][0] = 1;
            int nextNum = 1;
            Console.Write("The third array before conversion: ");
            for (int i = 0; i < 4 || nextNum < 4; i++)
            {
                arrayA[2][nextNum] = arrayA[2][i] * 10;
                Console.Write(arrayA[2][i] + "\t");
                nextNum++;
            }
            PrintSpace();
            Console.Write("The third array after conversion: ");
            for (int i = 0; i < 4; i++)
            {
                if (arrayA[2][i] == 0)
                    Console.Write("Not a number\t");
                else
                    Console.Write(Math.Log10(arrayA[2][i]) + "\t");
            }

            PrintSpace();
            PrintSpace();

            //----------------------//

            Console.WriteLine("Task B");
            Console.WriteLine("Task 5");

            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            Console.Write("First array: ");
            PrintArray(array);

            Console.Write("Second array: ");
            PrintArray(array2);
            
            Console.Write("Converted array2: ");
            Array.Copy(array, array2, 3);
            PrintArray(array2);

            PrintSpace();

            Console.WriteLine("Task 6");

            Console.Write("The original array: ");
            PrintArray(array);
            Console.Write($"Length array = {array.Length}");

            PrintSpace();
            PrintSpace();

            Array.Resize(ref array, 10);
            Console.Write("Converted array: ");
            PrintArray(array);
            Console.Write($"Length array = {array.Length}");
            

            PrintSpace();
        }
        static void PrintSpace()
        {
            Console.WriteLine();
        }
        static void PrintArray(int[] array)
        {
            foreach (int i in array)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
