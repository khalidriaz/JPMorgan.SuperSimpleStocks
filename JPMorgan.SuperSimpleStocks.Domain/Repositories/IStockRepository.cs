using System.Collections.Generic;

namespace JPMorgan.SuperSimpleStocks.Domain.Repositories
{
    public interface IStockRepository<T> where T : IStock
    {
        T FindBySymbol(string stockSymbol);
        void Add(T stock);
        bool Delete(T stock);
        IList<T> GetAll();
    }
}
