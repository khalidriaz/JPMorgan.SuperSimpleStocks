using JPMorgan.SuperSimpleStocks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Validate.NotNullOrEmpty<ITrade>("Trades", trades);

            trades.ForEach(trade => AddTrade(trade));
        }

        public void AddTrade(ITrade trade)
        {
            try
            {
                Validate.NotNull<ITrade>("Trade", trade);

                _tradeRepository.Add(trade);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public double GetVolumeWeightedStockPrice(TimeSpan? duration)
        {
            if (!duration.HasValue)
                duration = TimeSpan.FromMinutes(15);

            var endTime = DateTime.UtcNow;
            var startTime = endTime - duration;

            double volumeWeightedStockPrice = 0,
                totalTradePrice = 0,
                totalQuantity = 0;

            try
            {
                var trades = _tradeRepository.GetAll();

                if (trades != null)
                {
                    trades.Where(x => x.TimeStamp >= startTime && x.TimeStamp <= endTime)
                        .ToList().ForEach(trade =>
                        {
                            totalTradePrice += (trade.Price * trade.Quantity);
                            totalQuantity += trade.Quantity;
                        });

                    if (totalQuantity > 0)
                        volumeWeightedStockPrice = totalTradePrice / totalQuantity;
                }

                return volumeWeightedStockPrice;
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
