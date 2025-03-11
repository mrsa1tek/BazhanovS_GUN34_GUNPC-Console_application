using System.Threading.Channels;

namespace Collections
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2, or 3");
            int task = int.Parse(Console.ReadLine());
            switch (task)
            {
                case 1:
                    new Task1().TaskLoop();
                    break;
                case 2:
                    new Task2().TaskLoop();
                    break;
                case 3:
                    new Task3().TaskLoop();
                    break;
            }
        }
    }
}
