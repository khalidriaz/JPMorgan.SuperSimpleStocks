using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class Stock
    {
        readonly double _lastDividend;
        readonly double _fixedDividend;

        public double ParValue { get; private set; }// price in pennies
        public string StockSymbol { get; private set; }

        public Stock(string symbol, double parValue,
            double lastDividend, double fixedDividend = 0)
        {
            StockSymbol = symbol;
            ParValue = parValue;

            _lastDividend = lastDividend;
            _fixedDividend = fixedDividend;
        }

        public double GetDividendYeild(string stockSymbol, double marketPrice)
        {
            if (marketPrice == 0)
                throw new DivideByZeroException();

            double dividenYield = _lastDividend / marketPrice;
            return dividenYield;
        }
    }
}
