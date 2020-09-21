using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Test.Data
{
    public class BasicCalculatorData
    {
        public static IEnumerable<object[]> GetButtons()
        {
            yield return new object[] { "add", "Add (+)"};
            yield return new object[] {"subtract", "Subtract (−)"};
            yield return new object[] {"multiply", "Multiply (X)"};
            yield return new object[] {"divide", "Divide (/)"};
        }
        public static IEnumerable<object[]> GetAddCalculations()
        {
            yield return new object[] { "add", "4", "4", "8" };
            yield return new object[] { "add", "8", "4", "12" };
            yield return new object[] { "add", "1", "1", "2" };
        }
        public static IEnumerable<object[]> GetSubtractCalculations()
        {
            yield return new object[] { "subtract", "10", "4", "6" };
            yield return new object[] { "subtract", "8", "4", "4" };
            yield return new object[] { "subtract", "1", "1", "0" };
        }
        public static IEnumerable<object[]> GetMultiplyCalculations()
        {
            yield return new object[] { "multiply", "10", "4", "40" };
            yield return new object[] { "multiply", "8", "4", "32" };
            yield return new object[] { "multiply", "1", "1", "1" };
        }
        public static IEnumerable<object[]> GetDivideCalculations()
        {
            yield return new object[] { "divide", "10", "2", "5" };
            yield return new object[] { "divide", "8", "4", "2" };
            yield return new object[] { "divide", "1", "1", "1" };
        }

    }
}
