using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Test.Data
{
    public class ExtentedCalculatorData
    {
        public static IEnumerable<object[]> GetButtons()
        {
            yield return new object[] {"cuberoot", "CubeRoot (^(1/3))"};
            yield return new object[] {"xroot", "x-root (^(1/x))"};
            yield return new object[] {"power", "Power (^)"};
        }
        public static IEnumerable<object[]> GetXRootCalculations()
        {
            yield return new object[] { "xroot", "4", "2", "2"};
            yield return new object[] {"xroot", "64", "3", "4"};
        }
        public static IEnumerable<object[]> GetPowerCalculations()
        {
            yield return new object[] { "power", "10", "3", "1000" };
            yield return new object[] { "power", "8", "2", "64" };
            yield return new object[] { "power", "1", "1", "1" };
        }
        public static IEnumerable<object[]> GetCubeRootCalculations()
        {
            yield return new object[] { "cuberoot", "64", "4" };
            yield return new object[] { "cuberoot", "8", "2" };
        }
    }
}
