using JPMorgan.SuperSimpleStocks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain
{
    public class StockExchange : IStockExchange
    {
        readonly IStockRepository<IStock> _stockRepository;

        public StockExchange(IStockRepository<IStock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public void AddStock(List<IStock> stocks)
        {
            stocks.ForEach(stock => AddStock(stock));
        }

        public void AddStock(IStock stock)
        {
            _stockRepository.Add(stock);
        }

        public double GetDividendYeild(string stockSymbol, double marketPrice)
        {
            var stock = _stockRepository.FindBySymbol(stockSymbol);
            return stock.DividendYield(marketPrice);//validation for market price <= 0
        }

        public double GetPERatio(string stockSymbol, double marketPrice)
        {
            var stock = _stockRepository.FindBySymbol(stockSymbol);
            return stock.PERatio(marketPrice);//validation for market price <= 0
        }

        public double GetAllShareIndex()
        {
            var stocks = _stockRepository.GetAll().ToList();
            return GeometricMean(stocks);
        }

        private double GeometricMean(List<IStock> stocks)
        {
            double geometricMean = 0;
            if (stocks.Count > 0)
            {
                double productOfStocks = 1;
                stocks.ForEach(x => productOfStocks *= x.ParValue);
                var power = 1 / (double)stocks.Count;
                geometricMean = Math.Pow(productOfStocks, power);
            }
            return geometricMean;
        }
    }
}
