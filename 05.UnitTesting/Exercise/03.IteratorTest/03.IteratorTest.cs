using System;
using System.Linq;

namespace _03.IteratorTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ListIterator li = null;

            while (input != "END")
            {
                string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string command = data[0];
                    switch (command)
                    {
                        case "Create":
                            li = new ListIterator(data.Skip(1).ToArray());
                            break;
                        case "HasNext":
                            Console.WriteLine(li.HasNext());
                            break;
                        case "Move":
                            Console.WriteLine(li.Move());
                            break;
                        case "Print":
                            Console.WriteLine(li.Print());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }

        }
    }
}
