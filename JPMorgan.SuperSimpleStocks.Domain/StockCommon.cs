using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class StockCommon : Stock
    {
        public StockCommon(string symbol, double parValue, double lastDividend)
            : base(symbol, parValue, lastDividend)
        {
        }

        public override double DividendYield(double marketPrice)
        {
            if (marketPrice == 0)
                throw new DivideByZeroException();

            double dividenYield = _lastDividend / marketPrice;
            return dividenYield;
        }
    }
}
