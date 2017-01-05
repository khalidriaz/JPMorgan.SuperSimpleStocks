using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
