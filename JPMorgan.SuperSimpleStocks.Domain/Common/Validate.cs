using System;
using System.Collections.Generic;
using System.Linq;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class Validate
    {
        public static void NotNull<T>(string argumentName, T value)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName);
        }
        
        public static void NotNullOrEmpty<T>(string argumentName, IEnumerable<T> value)
        {
            NotNull(argumentName, value);
            NotEmpty(argumentName, value);
        }

        public static void NotEmpty<T>(string argumentName, IEnumerable<T> value)
        {
            if (!value.Any())
                throw new ArgumentException("Parameter must contain at least one element.", argumentName);
        }

        public static void GreaterThan(string argumentName, double value, double referencePoint)
        {
            if (value <= referencePoint)
                throw new ArgumentException($"Parameter must be greater than {referencePoint}. Was {value}.", argumentName);
        }

        public static void GreaterThan(string argumentName, DateTime value, DateTime referencePoint)
        {
            if (value <= referencePoint)
                throw new ArgumentException($"Parameter must be greater than {referencePoint}. Was {value}.", argumentName);
        }
    }
}
