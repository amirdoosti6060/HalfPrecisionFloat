namespace HalfPrecisionFloat
{
    public class MinMaxHandler : ICommandHandler
    {
        HalfPrecision _halfPrecision;

        public MinMaxHandler(HalfPrecision halfPrecision)
        {
            _halfPrecision = halfPrecision;
        }

        public void Execute(params string[] arguments)
        {
            _halfPrecision.GetMinMax();
        }
    }
}
