public class Program
{
    public static void Main(string[] args)
    {
        IWriter writer = new ConsoleWriter();
        IReader reader = new ConsoleReader();

        Engine engine = new Engine(writer, reader);
        engine.Run();
    }
}