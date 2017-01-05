using FluentAssertions;
using JPMorgan.SuperSimpleStocks.Domain;
using NUnit.Framework;
using System;

namespace JPMorgan.SuperSimpleStocks.Test
{
    [TestFixture]
    public class StockTests
    {
        [Test]
        public void Calculate_Dividend_Yield_Test_Returns()
        {
            var stock = new Stock();
            string stockSymbol = "POP";
            double marketPrice = 10;
            double dividend = stock.GetDividendYeild(stockSymbol, marketPrice);
            dividend.Should().BeApproximately(0.8, 0.01);
        }
    }
}
