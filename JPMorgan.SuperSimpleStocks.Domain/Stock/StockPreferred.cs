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
            Validate.GreaterThan("marketPrice", marketPrice, 0);

            //if (marketPrice == 0)
            //    throw new DivideByZeroException();

            double dividenYield = ((_fixedDividend / 100) * ParValue) / marketPrice;
            return dividenYield;
        }
    }
}
