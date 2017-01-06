using JPMorgan.SuperSimpleStocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPMorgan.SuperSimpleStocks.GBCExchangeApi.Data
{
    public class SampleStocks
    {
        public static List<IStock> Data
        {
            get
            {
                return new List<IStock>
                {
                    new StockCommon("TEA", 100, 0),
                    new StockCommon("POP", 100, 8),
                    new StockCommon("ALE", 60, 23),
                    new StockPreferred("GIN", 100, 8, 2),
                    new StockCommon("JOE", 250, 13)
                };
            }
        }
    }
}