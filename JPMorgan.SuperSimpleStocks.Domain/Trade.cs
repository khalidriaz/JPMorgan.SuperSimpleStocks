using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class Trade : ITrade
    {
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public TradeType TradeType { get; private set; }
        public DateTime TimeStamp { get; private set; }

        public Trade(double tradePrice, int quantity, DateTime timeStamp, TradeType tradeType)
        {
            Price = tradePrice;
            Quantity = quantity;
            TradeType = tradeType;
            TimeStamp = timeStamp;
        }
    }
}
