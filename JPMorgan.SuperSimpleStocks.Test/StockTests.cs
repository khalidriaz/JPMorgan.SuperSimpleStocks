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
        public void Stocks_Object_Is_Not_Null()
        {
            var stock = new Stock("POP", 100, 8);
            stock.Should().NotBeNull();
        }

        [Test]
        public void Calculate_Dividend_Yield_Test_Returns()
        {
            //Arrange
            var stock = new Stock("POP", 100, 8);

            //Act
            double dividend = stock.GetDividendYeild("POP", 10);

            //Assert
            dividend.Should().BeApproximately(0.8, 0.01);
        }
    }
}
