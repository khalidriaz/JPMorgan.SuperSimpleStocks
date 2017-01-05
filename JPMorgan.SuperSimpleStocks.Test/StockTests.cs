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
            var stock = new Stock("POP", 100, 8, StockType.Common);
            stock.Should().NotBeNull();
        }

        [Test]
        public void Calculate_Common_Stock_Dividend_Yield_Test()
        {
            //Arrange
            var stock = new Stock("POP", 100, 8, StockType.Common);

            //Act
            double dividend = stock.DividendYield(10);

            //Assert
            dividend.Should().BeApproximately(0.8, 0.01);
        }

        [Test]
        public void Calculate_Preferred_Stock_Dividend_Yield_Test()
        {
            //Arrange
            var stock = new Stock("GIN", 100, 8, StockType.Preferred, 2);

            //Act
            double dividend = stock.DividendYield(10);

            //Assert
            dividend.Should().BeApproximately(0.2, 0.01);
        }
    }
}
