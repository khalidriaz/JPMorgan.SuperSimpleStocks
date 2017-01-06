using JPMorgan.SuperSimpleStocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPMorgan.SuperSimpleStocks.GBCExchangeApi.Data
{
    public class SampleTrades
    {
        public static List<ITrade> Data
        {
            get
            {
                return new List<ITrade>
                {
                    new Trade(10, 5, DateTime.UtcNow.AddMinutes(-1), TradeType.Buy),
                    new Trade(17, 2, DateTime.UtcNow.AddMinutes(-2), TradeType.Buy),
                    new Trade(30, 7, DateTime.UtcNow.AddMinutes(-5), TradeType.Sell),
                    new Trade(15, 4, DateTime.UtcNow.AddMinutes(-8), TradeType.Buy),
                    new Trade(28, 9, DateTime.UtcNow.AddMinutes(-10), TradeType.Sell),
                    new Trade(34, 4, DateTime.UtcNow.AddMinutes(-12), TradeType.Sell),
                    new Trade(43, 5, DateTime.UtcNow.AddMinutes(-14), TradeType.Buy),
                    new Trade(27, 7, DateTime.UtcNow.AddMinutes(-16), TradeType.Buy),
                    new Trade(12, 4, DateTime.UtcNow.AddMinutes(-20), TradeType.Sell)
                };
            }
        }
    }
}