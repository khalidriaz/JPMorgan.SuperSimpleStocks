using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public abstract class Stock: IStock
    {
        protected readonly double _lastDividend;
        public double ParValue { get; private set; }// price in pennies
        public string StockSymbol { get; private set; }

        public Stock(string symbol, double parValue, double lastDividend)
        {
            StockSymbol = symbol;
            ParValue = parValue;

            _lastDividend = lastDividend;
        }

        public double PERatio(double marketPrice)
        {
            if (_lastDividend == 0)
                throw new DivideByZeroException("No dividend paid.");

            return marketPrice / _lastDividend;
        }

        public abstract double DividendYield(double marketPrice);
    }
}
