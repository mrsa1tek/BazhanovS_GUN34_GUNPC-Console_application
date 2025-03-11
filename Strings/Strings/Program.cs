using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            string str1 = "Hello";
            string str2 = " World";
            ConcatenateStrings(str1, str2);

            Console.WriteLine("Task 2");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorret data! Write the age from the numbers!");
                Console.ResetColor();
                return;
            }
            GreetUser(name, age);

            Console.WriteLine("Task 3");
            Console.Write("Enter string: ");
            string str3 = Console.ReadLine();
            Console.WriteLine(StringInfo(str3));

            Console.WriteLine("Task 4");
            Console.WriteLine(FirstFiveCharOfString(str3));

            Console.WriteLine("Task 5");
            string[] array = new string[] { "Health", "Armor", "Damage", "Speed", "Level", "Critical Damage" };
            Console.WriteLine(ConcatelementsArray(array));
        }

        static void ConcatenateStrings(string str1, string str2)
        {
            Console.WriteLine(String.Concat(str1, str2));
        }
        static void GreetUser(string name, int age)
        {
            Console.WriteLine($"Hello, {name}!\nYou are {age} years old");
        }
        static string StringInfo(string str)
        {
            return $"Length string : {str.Length}\n" +
                    $"String in upper register: {str.ToUpper()}\n" +
                    $"String in lowwer register: {str.ToLower()}";
        }
        static string FirstFiveCharOfString(string str)
        {
            if (str.Length < 5)
            {
                return str;
            }

            return str.Substring(0, 5);
        }

        static StringBuilder ConcatelementsArray(string[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str in array)
            {
                stringBuilder.Append(str);
                stringBuilder.Append(' ');
            }
            return stringBuilder;
        }
    }
}
