﻿using System;
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
        
        public static void NotEmpty<T>(string argumentName, IEnumerable<T> value)
        {
            if (!value.Any())
                throw new ArgumentException("Parameter must contain at least one element.", argumentName);
        }

        public static void NotNullOrEmpty<T>(string argumentName, IEnumerable<T> value)
        {
            NotNull(argumentName, value);
            NotEmpty(argumentName, value);
        }

        public static void NotNullOrEmpty(string argumentName, string value)
        {
            NotNull(argumentName, value);

            if (value.Length == 0)
                throw new ArgumentException("Parameter cannot be empty.", argumentName);
        }

        public static void GreaterThan(string argumentName, double value, double referencePoint)
        {
            if (value <= referencePoint)
                throw new ArgumentOutOfRangeException($"Parameter must be greater than {referencePoint}. Was {value}.", argumentName);
        }
    }
}
