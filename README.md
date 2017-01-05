
# JPMorgan.SuperSimpleStocks

Solution is developed in the Visual Studio 2015. 
In addition to using C# .Net, Following frameworks are used.

* NUnit 3
* Moq
* FluentAssertion

### Design decisions.


* **Repositories:**<br />
	Repository pattern is used for storing stocks and trades in memory. If in future we need to store it into a file or database we can extend `IStockRespository` and `ITradeRespository` interfaces.

* **Stock**:<br />
	Abstract class **Stock** which implements `IStock` interface. Classes `StockCommon` and `StockPreferred`, derived from this abstract class, implements **DividendYield** abstract method by *overriding* and using respective formula.
    
* **Trade**<br />
	Trade class contains properties to describe trade. This class contains no additional method as use cases didn't identified any. Method `VolumeWeightedStockPrice` seems more suitable to put outside in a service class called `Trading`.
    
* **StockExchange** <br />
	This class is more like a `service class` which have following public methods.
```
	AddStock
	GetDividendYield
	GetPERatio
	GetAllShareIndex
```
* **Trading**<br />
	This class is also more like a `service class` which have following public methods.
```
AddTrade
GetVolumeWeightedStockPrice
```
* **Validation**
	This class contains methods for validation and throws expceptions if valid parameters is not passed to the method in whihc these validation methods being called.
