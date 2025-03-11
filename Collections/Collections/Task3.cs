namespace Collections
{
    internal partial class Program
    {
        private class Task3
        {
            private DoubleLinkedNode<string> doubleLinkedNode = new DoubleLinkedNode<string> { };
            private int count;
            private string input;

            public void TaskLoop()
            {
                Console.WriteLine("Enter values ");
                while (count < 6)
                {
                    Console.Write("->");
                    input = Console.ReadLine();
                    doubleLinkedNode.Add(input);
                    count++;
                    if (count >= 3)
                    {
                        Console.WriteLine("Do you want to add another value? yes/no");
                        string response = Console.ReadLine().ToLower();
                        if (response != "yes")
                        {
                            break;
                        }
                        if (count > 6)
                            break;
                    }
                }
                if (count < 3)
                {
                    Console.WriteLine("You have entered less than 3 elements. Please run the program again and enter from 3 to 6 items.");
                }
                else
                {
                    Console.WriteLine("Your DoubleLinkedNode:");
                    doubleLinkedNode.Display();
                }
            }
        }
    }
}
