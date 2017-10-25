using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Day4
{
    public static class DoubleToBinary
    {
        public static string ToBinary(this double source)
        {
            Union union = new Union();
            union.Double = source;
            return union.Long.ToBinary();
        }

        private static string ToBinary(this long source)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= 64; ++i)
            {
                if ((source & 1) == 0)
                    builder.Insert(0, 0);
                else
                    builder.Insert(0, 1);
                source >>= 1;
            }
            return builder.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct Union
        {
            public long Long
            {
                get { return m_long; }
                set { m_long = value; }
            }

            public double Double
            {
                get { return m_double; }
                set { m_double = value; }
            }

            [FieldOffset(0)] private long m_long;
            [FieldOffset(0)] private double m_double;
        }
    }
}
