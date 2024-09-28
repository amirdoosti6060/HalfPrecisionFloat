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
            _halfPrecision.GetHalf(arguments[0]);
        }
    }
}
