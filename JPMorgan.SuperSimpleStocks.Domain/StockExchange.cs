using JPMorgan.SuperSimpleStocks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Validate.NotNullOrEmpty<IStock>("stocks", stocks);

            stocks.ForEach(stock => AddStock(stock));
        }

        public void AddStock(IStock stock)
        {
            try
            {
                Validate.NotNull<IStock>("stock", stock);

                _stockRepository.Add(stock);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public double GetDividendYeild(string stockSymbol, double marketPrice)
        {
            try
            {
                Validate.GreaterThan("marketPrice", marketPrice, 0);
                Validate.NotNullOrEmpty("stockSymbol", stockSymbol);

                var stock = _stockRepository.FindBySymbol(stockSymbol);
                return stock.DividendYield(marketPrice);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double GetPERatio(string stockSymbol, double marketPrice)
        {
            try
            {
                Validate.GreaterThan("marketPrice", marketPrice, 0);
                Validate.NotNullOrEmpty("stockSymbol", stockSymbol);

                var stock = _stockRepository.FindBySymbol(stockSymbol);
                return stock.PERatio(marketPrice);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public double GetAllShareIndex()
        {
            try
            {
                var stocks = _stockRepository.GetAll().ToList();
                return GeometricMean(stocks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private double GeometricMean(List<IStock> stocks)
        {
            try
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
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
