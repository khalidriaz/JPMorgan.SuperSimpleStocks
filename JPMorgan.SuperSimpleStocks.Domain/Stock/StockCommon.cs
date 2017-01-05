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
            Validate.GreaterThan("marketPrice", marketPrice, 0);   

            //if (marketPrice == 0)
            //    throw new DivideByZeroException();

            double dividenYield = _lastDividend / marketPrice;
            return dividenYield;
        }
    }
}
