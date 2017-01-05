using FluentAssertions;
using JPMorgan.SuperSimpleStocks.Domain;
using JPMorgan.SuperSimpleStocks.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Test
{
    [TestFixture]
    public class StockExchangeTests
    {
        Mock<IStockRepository<IStock>> _mockStockRepository;
        IStockExchange _stockExchange;

        [SetUp]
        public void SetUp()
        {
            _mockStockRepository = new Mock<IStockRepository<IStock>>();
            _mockStockRepository.Setup(x => x.GetAll()).Returns(new List<IStock>
                {
                    new StockCommon("TEA", 100, 0),
                    new StockCommon("POP", 100, 8),
                    new StockCommon("ALE", 60, 23),
                    new StockPreferred("GIN", 100, 8, 2),
                    new StockCommon("JOE", 250, 13)
                });

            _stockExchange = new StockExchange(_mockStockRepository.Object);
        }

        [Test]
        public void Stocks_Object_Is_Not_Null()
        {
            _stockExchange.Should().NotBeNull();
        }

        [Test]
        public void Get_All_Share_Index_Test()
        {
            //Arrange [Setup]

            //Act
            var result = _stockExchange.GetAllShareIndex();

            //Assert
            result.Should().BeApproximately(108.4471, 0.1);
        }

        [Test]
        public void Get_Common_Stock_Dividend_Yeild_Test()
        {
            //Arrange
            _mockStockRepository.Setup(x => x.FindBySymbol("POP"))
                .Returns(new StockCommon("POP", 100, 8));

            //Act
            var result = _stockExchange.GetDividendYeild("POP", 10);

            //Assert
            Assert.AreEqual(result, 0.8);
        }

        [Test]
        public void Get_Preferred_Stock_Dividend_Yeild_Test()
        {
            //Arrange
            _mockStockRepository.Setup(x => x.FindBySymbol("GIN"))
                .Returns(new StockPreferred("GIN", 100, 8, 2));

            //Act
            var result = _stockExchange.GetDividendYeild("GIN", 10);

            //Assert
            Assert.AreEqual(result, 0.2);
        }

        [Test]
        public void Get_P_E_Ratio_Test()
        {
            //Arrange
            _mockStockRepository.Setup(x => x.FindBySymbol("POP"))
                .Returns(new StockCommon("POP", 100, 8));

            //Act
            var result = _stockExchange.GetPERatio("POP", 120);

            //Assert
            result.Should().BeApproximately(15, 0.1);
        }

        [Test]
        public void Get_P_E_Ratio_Divide_By_Zero_Test()
        {
            //Arrange
            _mockStockRepository.Setup(x => x.FindBySymbol("TEA"))
                .Returns(new StockCommon("TEA", 100, 0));

            //Act 
            TestDelegate testDelegate = () => _stockExchange.GetPERatio("TEA", 120);

            //Assert
            Assert.Throws<DivideByZeroException>(testDelegate);
        }
    }
}
