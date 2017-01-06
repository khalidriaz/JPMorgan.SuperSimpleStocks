using System;

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
            try
            {
                Validate.GreaterThan("marketPrice", marketPrice, 0);

                double dividenYield = _lastDividend / marketPrice;
                return dividenYield;
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
