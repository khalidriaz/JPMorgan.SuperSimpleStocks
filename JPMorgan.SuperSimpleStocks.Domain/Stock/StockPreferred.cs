using System;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class StockPreferred : Stock
    {
        readonly double _fixedDividend;

        public StockPreferred(string symbol, double parValue, double lastDividend, double fixedDividend)
            : base(symbol, parValue, lastDividend)
        {
            _fixedDividend = fixedDividend;
        }

        public override double DividendYield(double marketPrice)
        {
            try
            {
                Validate.GreaterThan("marketPrice", marketPrice, 0);

                double dividenYield = ((_fixedDividend / 100) * ParValue) / marketPrice;
                return dividenYield;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
