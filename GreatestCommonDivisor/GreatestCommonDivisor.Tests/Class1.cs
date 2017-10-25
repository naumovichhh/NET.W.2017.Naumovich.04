using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Day4.Tests
{
    public class GreatestCommonDivisorTests
    {
        [TestCase(1, new int[2] { 1, 1 })]
        [TestCase(20, new int[2] { 20, 100 })]
        [TestCase(3, new int[2] { 9, 12 })]
        [TestCase(12, new int[2] { 12, -12 })]
        [TestCase(2, new int[4] { 2, 4, 8, -16 })]
        [TestCase(11, new int[6] { 11, 121, 198, -121, 110, 77 })]
        [TestCase(5, new int[5] { 1000, 30, 1341341415, 2000, -13413410})]
        public static void GetTest(int result, int[] args)
        {
            Assert.AreEqual(result, GreatestCommonDivisor.Get(args).Item1);
        }

        [TestCase(1, new int[2] { 1, 1 })]
        [TestCase(20, new int[2] { 20, 100 })]
        [TestCase(3, new int[2] { 9, 12 })]
        [TestCase(12, new int[2] { 12, -12 })]
        [TestCase(5, new int[3] { -10, 1120, 5 })]
        [TestCase(2, new int[4] { 2, 4, 8, -16 })]
        [TestCase(11, new int[6] { 11, 121, 198, -121, 110, 77 })]
        public static void GetBinaryTest(int result, int[] args)
        {
            Assert.AreEqual(result, GreatestCommonDivisor.GetBinary(args).Item1);
        }
    }
}
