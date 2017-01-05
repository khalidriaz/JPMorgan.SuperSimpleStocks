using System.Collections.Generic;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public interface IStockExchange
    {
        void AddStock(List<IStock> stocks);
        void AddStock(IStock stock);
        double GetAllShareIndex();
        double GetDividendYeild(string stockSymbol, double marketPrice);
        double GetPERatio(string stockSymbol, double marketPrice);
    }
}