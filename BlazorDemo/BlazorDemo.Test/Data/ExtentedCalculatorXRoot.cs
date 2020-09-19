using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Test.Data
{
    public class ExtentedCalculatorXRoot : IEnumerable<object[]>
    {
        private IEnumerable<Object[]> _data => new[]
        {
            new object[] { "xroot", "4", "2", "2" },
            new object[] { "xroot", "64", "3", "4" }
        };
        public IEnumerator<object[]> GetEnumerator()
            => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
         => GetEnumerator();
    }
}
