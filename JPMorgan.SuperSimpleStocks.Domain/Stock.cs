using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class Stock: IStock
    {
        readonly double _lastDividend;
        readonly double _fixedDividend;
        readonly StockType _stockType;
        public double ParValue { get; private set; }// price in pennies
        public string StockSymbol { get; private set; }

        public Stock(string symbol, double parValue,
            double lastDividend, StockType stockType, double fixedDividend = 0)
        {
            StockSymbol = symbol;
            ParValue = parValue;

            _lastDividend = lastDividend;
            _fixedDividend = fixedDividend;
            _stockType = stockType;
        }

        public double DividendYield(double marketPrice)
        {
            if (marketPrice == 0)
                throw new DivideByZeroException();

            double dividenYield = 0;

            if (_stockType == StockType.Common)
            {
                dividenYield = _lastDividend / marketPrice;
            }
            else if (_stockType == StockType.Preferred)
            {
                dividenYield = ((_fixedDividend / 100) * ParValue) / marketPrice;
            }
            
            return dividenYield;
        }

        public double PERatio(double marketPrice)
        {
            throw new NotImplementedException();
        }
    }
}
