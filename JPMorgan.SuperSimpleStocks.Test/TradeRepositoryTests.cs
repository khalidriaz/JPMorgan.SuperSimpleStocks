using NUnit.Framework;
using System;
using FluentAssertions;
using JPMorgan.SuperSimpleStocks.Domain.Repositories;
using JPMorgan.SuperSimpleStocks.Domain;

namespace JPMorgan.SuperSimpleStocks.Test
{
    [TestFixture]
    class TradeRepositoryTests
    {
        ITradeRepository<ITrade> _tradeRepository;

        [SetUp]
        public void SetUp()
        {
            _tradeRepository = new TradeRepository();
        }

        [Test]
        public void TradeRepository_Object_Is_Not_Null()
        {
            //Arrange-Act
            ITradeRepository<ITrade> repository = new TradeRepository();

            //Assert
            repository.Should().NotBeNull();
        }

        [Test]
        public void Add_Trade_To_Repostiroy_Test()
        {
            //Arrange
            ITrade trade = new Trade(10, 5, DateTime.UtcNow.AddMinutes(-1), TradeType.Buy);

            //Act
            _tradeRepository.Add(trade);

            //Assert
            _tradeRepository.GetAll().Count.ShouldBeEquivalentTo(1);
        }

        [Test]
        public void Delete_Trade_From_Repostiroy()
        {
            //Arrange
            ITrade trade = new Trade(30, 7, DateTime.UtcNow.AddMinutes(-5), TradeType.Sell);
            _tradeRepository.Add(trade);

            //Act
            _tradeRepository.Delete(trade);

            //Assert
            _tradeRepository.GetAll().Count.ShouldBeEquivalentTo(0);
        }

        [Test]
        public void FindByTimeStamp_Returns_The_Trade()
        {
            //Arrange
            DateTime timestamp = DateTime.UtcNow - TimeSpan.FromMinutes(10);

            ITrade trade = new Trade(28, 9, timestamp, TradeType.Sell);
            _tradeRepository.Add(trade);

            //Act
            var result = _tradeRepository.FindByTimeStamp(timestamp);

            //Assert
            result.Should().NotBeNull();
            result.Quantity.ShouldBeEquivalentTo(9);
        }

        [Test]
        public void Add_Two_Records_In_Repository_GetAll_Method_Returns_2_Stocks()
        {
            //Arrange
            _tradeRepository.Add(new Trade(34, 4, DateTime.UtcNow.AddMinutes(-12), TradeType.Sell));
            _tradeRepository.Add(new Trade(43, 5, DateTime.UtcNow.AddMinutes(-15), TradeType.Buy));

            //Act
            var result = _tradeRepository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Count.ShouldBeEquivalentTo(2);
        }
    }
}
