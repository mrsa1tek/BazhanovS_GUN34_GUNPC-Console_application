namespace Collections
{
    internal partial class Program
    {
        private class Task1
        {
            private List<string> listStr = new List<string> {
            "string1",
            "string2",
            "string3"};

            public void TaskLoop()
            {
                Console.WriteLine("Enter string: ");
                string userEnter = Console.ReadLine();
                listStr.Add(userEnter);

                Console.WriteLine("List: ");
                foreach (string str in listStr)
                {
                    Console.Write(str + "\t");
                }

                Console.WriteLine();

                Console.WriteLine("Enter string again: ");
                userEnter = Console.ReadLine();
                listStr.Insert(listStr.Count / 2, userEnter);

                Console.WriteLine(string.Join("\t", listStr));
            }
        }
    }
}
