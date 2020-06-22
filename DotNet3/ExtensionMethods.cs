using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet3
{
    public static class ExtensionMethods
    {
        //sum, product, min, max, average.
        public static int Product(this IEnumerable<int> values)
        {
            return values.Aggregate((a, b) => a * b);
        }

        public static int Sum(this IEnumerable<int> values)
        {
            return values.Aggregate((a, b) => a + b);
        }

        public static int Min(this IEnumerable<int> values)
        {
            return values.Aggregate((a, b) => a < b ? a : b);
        }

        public static int Max(this IEnumerable<int> values)
        {
            return values.Aggregate((a, b) => a > b ? a : b);
        }
    }
}
