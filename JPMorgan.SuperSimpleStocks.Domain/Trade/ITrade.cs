using System;

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
