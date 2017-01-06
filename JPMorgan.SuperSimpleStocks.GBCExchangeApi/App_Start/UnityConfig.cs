using JPMorgan.SuperSimpleStocks.Domain;
using JPMorgan.SuperSimpleStocks.Domain.Repositories;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace JPMorgan.SuperSimpleStocks.GBCExchangeApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IStockExchange, StockExchange>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrading, Trading>(new HierarchicalLifetimeManager());

            container.RegisterType<IStockRepository<IStock>, StockRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITradeRepository<ITrade>, TradeRepository>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}