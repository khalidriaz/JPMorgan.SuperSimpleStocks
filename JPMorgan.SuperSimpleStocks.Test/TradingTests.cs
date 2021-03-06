﻿using FluentAssertions;
using JPMorgan.SuperSimpleStocks.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace JPMorgan.SuperSimpleStocks.Domain.UnitTest
{
    [TestFixture]
    class TradingTests
    {
        Mock<ITradeRepository<ITrade>> _mockTradeRepository;
        ITrading _trading;

        [SetUp]
        public void SetUp()
        {
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
            //Moq framework being used, otherwise this becomes integration test rather unit test.

            _trading = new Trading(_mockTradeRepository.Object);
        }

        [Test]
        public void Trading_Object_Is_Not_Null()
        {
            _trading.Should().NotBeNull();
        }

        [Test]
        public void Volume_Weighted_Stock_Price_Without_Sepcifying_TimeSpan_Returns_Result_Test()
        {
            //Arrange
            
            //Act
            var result = _trading.GetVolumeWeightedStockPrice();

            //Assert
            result.Should().BeApproximately(26.5833, 0.001);
        }

        [Test]
        public void Volume_Weighted_Stock_Price_Return_Last_15_Minutes_Test()
        {
            //Arrange
            var timeSpan = TimeSpan.FromMinutes(15);

            //Act
            var result = _trading.GetVolumeWeightedStockPrice(timeSpan);

            //Assert
            result.Should().BeApproximately(26.5833, 0.001);
        }
    }
}
