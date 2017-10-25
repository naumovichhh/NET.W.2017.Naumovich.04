using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Day4
{
    public static class GreatestCommonDivisor
    {
        public static Tuple<int, long> Get(params int[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            GetExceptions(args);
            int intermediateResult = args[0];
            for (int i = 1; i < args.Length; ++i)
            {
                intermediateResult = Euclide(intermediateResult, args[i]);
            }
            watch.Stop();
            long ticks = watch.Elapsed.Ticks;
            return new Tuple<int, long>(intermediateResult, ticks);
        }

        public static Tuple<int, long> GetBinary(params int[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            GetExceptions(args);
            int intermediateResult = args[0];
            for (int i = 1; i < args.Length; ++i)
            {
                intermediateResult = BinaryEuclide(intermediateResult, args[i]);
            }
            watch.Stop();
            long ticks = watch.Elapsed.Ticks;
            return new Tuple<int, long>(intermediateResult, ticks);
        }

        private static int BinaryEuclide(int a, int b)
        {
            EuclideExceptions(a, b);
            EuclideDoAbs(ref a, ref b);
            int shiftCount = 1;
            while (((a | b) & 1) == 0)
            {
                a >>= 1;
                b >>= 1;
                shiftCount <<= 1;
            }
            while ((a & 1) == 0)
                a >>= 1;
            while ((b & 1) == 0)
                b >>= 1;                
            return EuclideAlgorithm(a, b) * shiftCount;
        }

        private static int Euclide(int a, int b)
        {
            EuclideExceptions(a, b);
            EuclideDoAbs(ref a, ref b);
            return EuclideAlgorithm(a, b);
        }

        private static int EuclideAlgorithm(int a, int b)
        {
            while (a != b)
                if (a > b)
                    a -= b;
                else
                    b -= a;
            return a;
        }

        private static void GetExceptions(int[] args)
        {
            if (args.Length <= 1)
                throw new ArgumentException("Should be at least two arguments");
        }

        private static void EuclideExceptions(int a, int b)
        {
            if (a == 0)
                throw new ArgumentException("Argument can't be zero");
            if (b == 0)
                throw new ArgumentException("Argument can't be zero");
        }

        private static void EuclideDoAbs(ref int a, ref int b)
        {
            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;
        }
    }
}
