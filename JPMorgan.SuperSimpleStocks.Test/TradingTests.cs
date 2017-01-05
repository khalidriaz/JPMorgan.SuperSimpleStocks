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
    class TradingTests
    {
        Mock<ITradeRepository<ITrade>> _mockTradeRepository;
        ITrading _trading;

        [SetUp]
        public void SetUp()
        {
            //Moq framework being used, otherwise this become integration test rather unit test.

            _mockTradeRepository = new Mock<ITradeRepository<ITrade>>();
            _mockTradeRepository.Setup(x => x.GetAll()).Returns(new List<ITrade>
                {
                    new Trade(10, 5, DateTime.UtcNow.AddMinutes(-1), TradeType.Buy),
                    new Trade(17, 2, DateTime.UtcNow.AddMinutes(-2), TradeType.Buy),
                    new Trade(30, 7, DateTime.UtcNow.AddMinutes(-5), TradeType.Sell),
                    new Trade(15, 4, DateTime.UtcNow.AddMinutes(-8), TradeType.Buy),
                    new Trade(28, 9, DateTime.UtcNow.AddMinutes(-10), TradeType.Sell),
                    new Trade(34, 4, DateTime.UtcNow.AddMinutes(-12), TradeType.Sell),
                    new Trade(43, 5, DateTime.UtcNow.AddMinutes(-14), TradeType.Buy),
                    new Trade(27, 7, DateTime.UtcNow.AddMinutes(-16), TradeType.Buy),
                    new Trade(12, 4, DateTime.UtcNow.AddMinutes(-20), TradeType.Sell)
                });

            _trading = new Trading(_mockTradeRepository.Object);
        }

        [Test]
        public void Trading_Object_Is_Not_Null()
        {
            _trading.Should().NotBeNull();
        }

        [Test]
        public void Volume_Weighted_Stock_Price_Test()
        {
            //Arrange
            DateTime startTime, endTime;
            
            endTime = DateTime.UtcNow;
            startTime = endTime.AddMinutes(-15);

            //Act
            var result = _trading.GetVolumeWeightedStockPrice(startTime, endTime);

            //Assert
            result.Should().BeApproximately(26.5833, 0.001);
        }

        [Test]
        public void Volume_Weighted_Stock_Price_Test_Throws_Exception_On_DateTime_MinValue()
        {
            //Arrange
            DateTime startTime = new DateTime();//Initialized with minimum datetime as default.
            DateTime endTime = new DateTime();

            //Act
            TestDelegate testDelegate = () => _trading.GetVolumeWeightedStockPrice(startTime, endTime);

            //Assert
            Assert.Throws<ArgumentException>(testDelegate);
        }
    }
}
