using System;

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
                throw new DivideByZeroException("Invalid dividend value provided for PERatio.");

            return marketPrice / _lastDividend;
        }

        public abstract double DividendYield(double marketPrice);
    }
}
