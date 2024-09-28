namespace HalfPrecisionFloat
{
    public class CommandLineParser
    {
        Command[] _commands;
        string[] _args;

        public CommandLineParser(Command[] commands, string[] args)
        {
            _commands = commands;    
            _args = args;
        }

        public bool Parse()
        {
            if (_args.Length < 1)
            {
                Usage();
                return false;
            }

            var qry = _commands.Where(n => String.Compare(n.Name, _args[0], true) == 0).FirstOrDefault();
            if (qry == null)
            {
                Usage();
                return false;
            }

            if (_args.Length - 1 != qry.NumberOfParameters)
            {
                Usage();
                return false;
            }

            qry.Handler.Execute(_args.Skip(1).ToArray());
            return true;
        }

        void Usage()
        {
            Console.WriteLine("HalfPrecisionFloat command {param1} {param2}");
            Console.WriteLine("command: ");
            foreach (var cmd in _commands)
                Console.WriteLine($"\t{cmd.Name} - {cmd.Description}");
        }
    }
}
