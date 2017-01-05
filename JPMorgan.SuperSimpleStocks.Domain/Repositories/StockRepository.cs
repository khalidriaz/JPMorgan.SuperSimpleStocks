using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Domain.Repositories
{
    public class StockRepository : IStockRepository<IStock>
    {
        readonly IList<IStock> _list;

        public StockRepository()
        {
            _list = new List<IStock>();
        }

        public void Add(IStock stock)
        {
            Validate.NotNull<IStock>("stock", stock);
            _list.Add(stock);
        }

        public bool Delete(IStock stock)
        {
            Validate.NotNull<IStock>("stock", stock);
            return _list.Remove(stock);
        }

        public IStock FindBySymbol(string stockSymbol)
        {
            return _list.FirstOrDefault(x => x.StockSymbol == stockSymbol);
        }

        public IList<IStock> GetAll()
        {
            return _list;
        }
    }
}
