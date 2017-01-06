using System;
using System.Collections.Generic;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public interface ITrading
    {
        void AddTrade(List<ITrade> trades);
        void AddTrade(ITrade trade);

        /// <summary>
        /// [duration] is an optional parameter.
        /// If not provided return value will be based on last 15 minutes.
        /// </summary>
        /// <param name="duration">optional parameter</param>
        /// <returns></returns>
        double GetVolumeWeightedStockPrice(TimeSpan? duration = null);
    }
}