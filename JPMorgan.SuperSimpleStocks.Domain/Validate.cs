using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class Validate
    {
        public static void NotNull<T>(string argumentName, T value) where T : class
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
    }
}
