using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public interface ITrade
    {
        double Price { get; }
        int Quantity { get; }
        TradeType TradeType { get; }
        DateTime TimeStamp { get; }
    }
}
