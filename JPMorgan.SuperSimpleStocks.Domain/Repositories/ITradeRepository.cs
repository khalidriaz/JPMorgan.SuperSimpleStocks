using System;
using System.Collections.Generic;

namespace JPMorgan.SuperSimpleStocks.Domain.Repositories
{
    public interface ITradeRepository<T> where T : ITrade
    {
        T FindByTimeStamp(DateTime timeStamp);
        void Add(T trade);
        bool Delete(T trade);
        IList<T> GetAll();
    }
}
