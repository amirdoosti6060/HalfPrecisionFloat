namespace HalfPrecisionFloat
{
    public class AddHandler: ICommandHandler
    {
        HalfPrecision _halfPrecision;

        public AddHandler(HalfPrecision halfPrecision)
        {
            _halfPrecision = halfPrecision;
        }

        public void Execute(params string[] arguments)
        {
            double p1, p2;
            p1 = double.Parse(arguments[0]);
            p2 = double.Parse(arguments[1]);
            _halfPrecision.AddHalf(p1, p2);
        }
    }
}
