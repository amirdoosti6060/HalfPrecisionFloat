using System.Collections.Concurrent;

namespace HalfPrecisionFloat
{
    public class HalfPrecision
    {
        public void GetRange(double from_num, double to_num)
        {
            Half h1 = (Half)from_num;
            Half h2 = (Half)to_num;

            var allHalfs = GenerateAllPossibleHalfNumbers();
            PrintInRange(allHalfs, h1, h2);
        }

        public void GetMinMax()
        {
            Half minHalf = Half.MinValue;
            Half maxHalf = Half.MaxValue;

            double minPosSub = Math.Pow(2.0, -14) * 1.0D / 1024.0D;
            double maxPosSub = Math.Pow(2.0, -14) * 1023.0D / 1024.0D;
            double minNorm = Math.Pow(2.0, 15) * (1.0 + 0.0 / 1024.0D);
            double maxNorm = Math.Pow(2.0, 15) * (1.0 + 1023.0 / 1024.0D);

            Console.WriteLine($"Minimum Positive Subnormal Number = {minPosSub.ToString("0.############################")}");
            Console.WriteLine($"Maximum Positive Subnormal Number = {maxPosSub.ToString("0.############################")}");
            Console.WriteLine($"Minimum Positive Normal Number = {minNorm.ToString("0.############################")}");
            Console.WriteLine($"Maximum Positive Normal Number = {maxNorm.ToString("0.############################")}");

            Console.WriteLine($"Min Half Value = {minHalf}");
            Console.WriteLine($"Max Half Value = {maxHalf}");
        }

        public void GetBinary(double num)
        {
            Half half = (Half)num;
            DisplayHalfBinary(half);
        }

        public void GetHalf(string num)
        {
            Half h1 = (Half)Convert.ToDouble(num);
            Console.WriteLine($"Number: {num} -> Half: {h1.ToString("0.############################")}");
        }

        public void AddHalf(double p1, double p2)
        {
            Half h1 = (Half)p1;
            Half h2 = (Half)p2;
            Half h3 = h1 + h2;


            Console.WriteLine($"Original {p1} + {p2} =");
            Console.WriteLine($"Half {h1} + {h2} = {h3.ToString("0.############################")}");
        }

        private SortedSet<Half> GenerateAllPossibleHalfNumbers()
        {

            ConcurrentBag<Half> halfNumbers = new ConcurrentBag<Half>();

            // Normal number fall into this range: [2047, 31743]
            Parallel.For(2047, 31743 + 1, i =>
            {
                Half halfValue = BitConverter.UInt16BitsToHalf((ushort)i);
                if (!Half.IsNaN(halfValue) && !Half.IsNegativeInfinity(halfValue) && !Half.IsPositiveInfinity(halfValue))
                    halfNumbers.Add(halfValue);
            });

            SortedSet<Half> sortedHalfs = [(Half)0, .. halfNumbers];

            return sortedHalfs;
        }

        private void PrintInRange(SortedSet<Half> allNum, Half h1, Half h2)
        {
            var qry = allNum.Where(n => n >= h1 && n <= h2).ToList();

            foreach (var num in qry)
                Console.WriteLine(num.ToString("0.############################"));
        }

        private void DisplayHalfBinary(Half h)
        {
            ushort halfBits = BitConverter.HalfToUInt16Bits(h);
            string binaryRepresentation = Convert.ToString(halfBits, 2).PadLeft(16, '0');
            Console.WriteLine($"Half Number: {h}");
            Console.WriteLine($"Binary Representation: {binaryRepresentation}");
        }
    }
}
