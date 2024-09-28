namespace HalfPrecisionFloat
{
    public class ConvertHandler: ICommandHandler
    {
        HalfPrecision _halfPrecision;

        public ConvertHandler(HalfPrecision halfPrecision)
        {
            _halfPrecision = halfPrecision;
        }

        public void Execute(params string[] arguments)
        {
            double p;
            p = double.Parse(arguments[0]);
            _halfPrecision.GetHalf(p);
        }
    }
}
