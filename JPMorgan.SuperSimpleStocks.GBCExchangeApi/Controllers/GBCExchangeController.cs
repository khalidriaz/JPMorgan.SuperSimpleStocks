using JPMorgan.SuperSimpleStocks.Domain;
using JPMorgan.SuperSimpleStocks.GBCExchangeApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JPMorgan.SuperSimpleStocks.GBCExchangeApi.Controllers
{
    public class GBCExchangeController : ApiController
    {
        readonly IStockExchange _stockExchange;
        readonly ITrading _trading;
        public GBCExchangeController(IStockExchange stockExchange, ITrading exchange)
        {
            _trading = exchange;
            _trading.AddTrade(SampleTrades.Data);

            _stockExchange = stockExchange;
            _stockExchange.AddStock(SampleStocks.Data);
        }

        // GET: api/AllShareIndex
        [HttpGet]
        [ActionName("AllShareIndex")]
        public double GetAllShareIndex()
        {
            try
            {
                return _stockExchange.GetAllShareIndex();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/DividendYield
        [HttpGet]
        [ActionName("DividendYield")]
        public double GetDividendYield(string stockSymbol, double marketPrice)
        {
            try
            {
                return Math.Round(_stockExchange.GetDividendYeild(stockSymbol, marketPrice), 4, MidpointRounding.AwayFromZero);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/PERatio
        [HttpGet]
        [ActionName("PERatio")]
        public double GetPERatio(string stockSymbol, double marketPrice)
        {
            try
            {
                return Math.Round(_stockExchange.GetPERatio(stockSymbol, marketPrice), 4, MidpointRounding.AwayFromZero);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/VolumeWeightedStockPrice
        [HttpGet]
        [ActionName("VolumeWeightedStockPrice")]
        public double GetVolumeWeightedStockPrice()
        {
            try
            {
                return Math.Round(_trading.GetVolumeWeightedStockPrice(), 4, MidpointRounding.AwayFromZero);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
