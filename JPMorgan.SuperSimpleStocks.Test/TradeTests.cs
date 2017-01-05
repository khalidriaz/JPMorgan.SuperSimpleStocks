using FluentAssertions;
using JPMorgan.SuperSimpleStocks.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorgan.SuperSimpleStocks.Test
{
    [TestFixture]
    class TradeTests
    {
        [Test]
        public void Trade_Object_Is_Not_Null()
        {
            //Arrange-Act
            ITrade trade = new Trade(10, 5, DateTime.UtcNow.AddMinutes(-1), TradeType.Buy);

            //Assert
            trade.Should().NotBeNull();
        }
    }
}
