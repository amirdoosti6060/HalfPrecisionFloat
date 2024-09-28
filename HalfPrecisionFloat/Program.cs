namespace HalfPrecisionFloat
{
    public class Program
    {
        static void Main(string[] args)
        {
            HalfPrecision halfPrecision = new HalfPrecision();

            Command[] commands = new[]
            {
                new Command { Name = "range", Description = "return all available Half numbers between {param1} and {param2}", NumberOfParameters = 2, Handler = new GetRangeHandler(halfPrecision)},
                new Command { Name = "minmax", Description = "return the minimum and maximum possible Half number", NumberOfParameters = 0, Handler = new MinMaxHandler(halfPrecision)},
                new Command { Name = "binary", Description = "convert the {param1} to binary", NumberOfParameters = 1, Handler = new BinaryHandler(halfPrecision)},
                new Command { Name = "convert", Description = "convert the {param1} to Half number.", NumberOfParameters = 1, Handler = new ConvertHandler(halfPrecision)},
                new Command { Name = "add", Description = "add {param1} to {param2} and return the result", NumberOfParameters = 2, Handler = new AddHandler(halfPrecision)}
            };

            CommandLineParser commandLineParser = new CommandLineParser(commands, args);

            if (!commandLineParser.Parse())
                return;

            Console.WriteLine("Finished.");
        }
    }
}
