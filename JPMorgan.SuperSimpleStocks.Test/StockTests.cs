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
            //Arrange-Act
            IStock stock = new StockCommon("POP", 100, 8);

            //Assert
            stock.Should().NotBeNull();
        }

        [Test]
        public void Calculate_Common_Stock_Dividend_Yield_Test()
        {
            //Arrange
            IStock stock = new StockCommon("POP", 100, 8);

            //Act
            double dividend = stock.DividendYield(10);

            //Assert
            dividend.Should().BeApproximately(0.8, 0.01);
        }

        [Test]
        public void Calculate_Preferred_Stock_Dividend_Yield_Test()
        {
            //Arrange
            IStock stock = new StockPreferred("GIN", 100, 8, 2);

            //Act
            double dividend = stock.DividendYield(10);

            //Assert
            dividend.Should().BeApproximately(0.2, 0.01);
        }

        [Test]
        public void Get_P_E_Ratio_Test()
        {
            //Arrange
            IStock stock = new StockCommon("POP", 100, 8);

            //Act
            var result = stock.PERatio(120);

            //Assert
            result.Should().BeApproximately(15, 0.1);
        }

        [Test]
        public void Get_P_E_Ratio_Divide_By_Zero_Test()
        {
            //Arrange
            IStock stock = new StockCommon("TEA", 100, 0);

            //Act 
            TestDelegate testDelegate = () => stock.PERatio(120);

            //Assert
            Assert.Throws<DivideByZeroException>(testDelegate);
        }
    }
}
