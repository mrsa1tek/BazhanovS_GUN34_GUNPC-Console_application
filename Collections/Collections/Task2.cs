namespace Collections
{
    internal partial class Program
    {
        private class Task2
        {
            private Dictionary<string, byte> students = new Dictionary<string, byte>
            {
                {"Andrey",3 },
                {"Alexander", 5 },
                {"Sonya", 5 }
            };
            public void TaskLoop()
            {
                string studentName;
                byte studentRate;


                Console.Write("Enter name: ");
                studentName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(studentName))
                {
                    Console.WriteLine("Incorrect student name");
                    return;
                }

                Console.Write("Enter rate: ");
                if (!byte.TryParse(Console.ReadLine(),out studentRate) || studentRate < 2 || studentRate > 5)
                {
                    Console.WriteLine("Error: incorrect rate! Avalibale rates: from 2 to 5");
                    return;
                }

                if (students.TryAdd(studentName, studentRate))
                {
                    Console.WriteLine("Success! Student is added");
                }
                else
                {
                    Console.WriteLine("Error! This student with such name already exist");
                    return;
                }

                Console.Write("Enter student name: ");
                studentName = Console.ReadLine();

                if (students.TryGetValue(studentName, out studentRate))
                {
                    Console.WriteLine($"Rate of {studentName} is {studentRate}");
                }
                else
                {
                    Console.WriteLine("Error! Stundet not found!");
                    return;
                }

            }
        }
    }
}
