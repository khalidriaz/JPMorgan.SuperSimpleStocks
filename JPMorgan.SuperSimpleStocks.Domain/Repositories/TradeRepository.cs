﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _list.Add(trade);
        }

        public bool Delete(ITrade trade)
        {
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
