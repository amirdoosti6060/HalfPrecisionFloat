namespace HalfPrecisionFloat
{
    public class Command
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumberOfParameters { get; set; }
        public ICommandHandler Handler { get; set; }
    }
}
