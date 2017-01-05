using System;
using System.Collections.Generic;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public interface ITrading
    {
        void AddTrade(List<ITrade> trades);
        void AddTrade(ITrade trade);
        double GetVolumeWeightedStockPrice(DateTime startDateTime, DateTime endDateTime);
    }
}