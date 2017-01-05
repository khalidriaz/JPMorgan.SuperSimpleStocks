namespace JPMorgan.SuperSimpleStocks.Domain
{
    public interface IStock
    {
        double ParValue { get; }
        string StockSymbol { get; }
        double DividendYield(double marketPrice);
        double PERatio(double marketPrice);
    }
}
