using System;
using System.Collections.Generic;
using System.Linq;

namespace JPMorgan.SuperSimpleStocks.Domain.Repositories
{
    public class TradeRepository : ITradeRepository<ITrade>
    {
        readonly IList<ITrade> _list;
        public TradeRepository()
        {
            _list = new List<ITrade>();
        }
        public void Add(ITrade trade)
        {
            Validate.NotNull<ITrade>("trade", trade);
            _list.Add(trade);
        }

        public bool Delete(ITrade trade)
        {
            Validate.NotNull<ITrade>("trade", trade);
            return _list.Remove(trade);
        }

        public ITrade FindByTimeStamp(DateTime timeStamp)
        {
            return _list.FirstOrDefault(trade => trade.TimeStamp == timeStamp);
        }

        public IList<ITrade> GetAll()
        {
            return _list;
        }
    }
}
