namespace HalfPrecisionFloat
{
    public class BinaryHandler: ICommandHandler
    {
        HalfPrecision _halfPrecision;

        public BinaryHandler(HalfPrecision halfPrecision)
        {
            _halfPrecision = halfPrecision;
        }

        public void Execute(params string[] arguments)
        {
            double p = double.Parse(arguments[0]);
            _halfPrecision.GetBinary(p);
        }
    }
}
