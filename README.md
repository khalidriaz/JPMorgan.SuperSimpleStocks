# JPMorgan.SuperSimpleStocks

Solution is developed in the Visual Studio 2015. 
In addition to using C# .Net, Following frameworks are used.

* NUnit
* Moq

### Design decisions.


* **Repositories:**<br />
	Repository pattern is used for storing stocks and trades in memory. If in future we need to store it into a file or database we can extend `IStockRespository` and `ITradeRespository` interfaces.

* **Stock**:<br />
	Abstract class **Stock** which implements `IStock` interface. Classes `StockCommon` and `StockPreferred`, derived from this abstract class, implements **DividendYield** abstract method by *overriding* and using respective formula.
    
* **Trade**
* *StockExchange*
* *Trading*

**Stock**: This is abstract class and user can only initiate derived classes `PreferredStock` and `CommonStock`
