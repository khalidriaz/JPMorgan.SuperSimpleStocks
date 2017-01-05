using JPMorgan.SuperSimpleStocks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class Trading : ITrading
    {
        readonly ITradeRepository<ITrade> _tradeRepository;

        public Trading(ITradeRepository<ITrade> tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public void AddTrade(List<ITrade> trades)
        {
            trades.ForEach(trade => AddTrade(trade));
        }

        public void AddTrade(ITrade trade)
        {
            _tradeRepository.Add(trade);
        }

        public double VolumeWeightedStockPrice(TimeSpan duration)
        {
            var trades = _tradeRepository.GetAll();

            var endTime = DateTime.UtcNow;
            var startTime = endTime - duration;

            double volumeWeightedStockPrice = 0,
                totalTradePrice = 0,
                totalQuantity = 0;

            if (trades == null)
                throw new ArgumentNullException();

            trades.Where(x => x.TimeStamp >= startTime && x.TimeStamp <= endTime)
                .ToList().ForEach(trade =>
                {
                    totalTradePrice += (trade.Price * trade.Quantity);
                    totalQuantity += trade.Quantity;
                });

            if (totalQuantity > 0)
                volumeWeightedStockPrice = totalTradePrice / totalQuantity;

            return volumeWeightedStockPrice;
        }
    }
}
