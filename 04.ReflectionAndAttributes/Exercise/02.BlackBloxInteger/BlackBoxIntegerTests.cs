namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            var blackBox = Activator.CreateInstance(type, true);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];
                int param = int.Parse(data[1]);

                var method =  type
                    .GetMethod(action, BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(blackBox, new object[] { param });

                var fieldValue = type
                    .GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(blackBox);

                Console.WriteLine(fieldValue);

                input = Console.ReadLine();
            }
        }
    }
}
