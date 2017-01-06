using NUnit.Framework;
using FluentAssertions;
using JPMorgan.SuperSimpleStocks.Domain.Repositories;

namespace JPMorgan.SuperSimpleStocks.Domain.UnitTest
{
    [TestFixture]
    class StockRepositoryTests
    {
        IStockRepository<IStock> _stockRepository;

        [SetUp]
        public void SetUp()
        {
            _stockRepository = new StockRepository();
        }

        [Test]
        public void StockRepository_Object_Is_Not_Null()
        {
            //Arrange-Act
            IStockRepository<IStock> repository = new StockRepository();

            //Assert
            repository.Should().NotBeNull();
        }

        [Test]
        public void Add_Common_Stock_To_Repostiroy()
        {
            //Arrange
            IStock stock = new StockCommon("POP", 100, 8);

            //Act
            _stockRepository.Add(stock);

            //Assert
            _stockRepository.GetAll().Count.ShouldBeEquivalentTo(1);
        }

        [Test]
        public void Delete_Preferred_Stock_To_Repostiroy()
        {
            //Arrange
            IStock stock = new StockPreferred("GIN", 100, 8, 2);
            _stockRepository.Add(stock);

            //Act
            _stockRepository.Delete(stock);

            //Assert
            _stockRepository.GetAll().Count.ShouldBeEquivalentTo(0);
        }

        [Test]
        public void FindBySymbol_with_GIN_Returns_Preferred_Stock()
        {
            //Arrange
            IStock stock = new StockPreferred("GIN", 100, 8, 2);
            _stockRepository.Add(stock);

            //Act
            var result = _stockRepository.FindBySymbol("GIN");

            //Assert
            result.Should().NotBeNull();
            result.StockSymbol.ShouldBeEquivalentTo("GIN");
        }

        [Test]
        public void Add_Two_Records_In_Repository_GetAll_Method_Returns_2_Stocks()
        {
            //Arrange
            _stockRepository.Add(new StockPreferred("GIN", 100, 8, 2));
            _stockRepository.Add(new StockCommon("JOE", 250, 13));

            //Act
            var result = _stockRepository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Count.ShouldBeEquivalentTo(2);
        }
    }
}
