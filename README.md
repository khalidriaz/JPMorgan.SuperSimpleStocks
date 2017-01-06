# JPMorgan.SuperSimpleStocks

Solution is developed in the Visual Studio 2015. 
In addition to using C# .Net, Following frameworks are used.

* NUnit 3
* Moq
* FluentAssertion


### Solution structure

This solution contains `three projects`. README file is in the *Solution Items* folder.

* **JPMorgan.SuperSimpleStocks.Domain** <br />
Project contains domain logic classes to implement the requirenments.
* **JPMorgan.SuperSimpleStocks.Domain.UnitTest** <br />
Unit test project for the `Domain` project classes. To run these unit tests NUnit Test Adapter 3.6 is required which can be [added](http://bit.ly/2jioreb) to the visual studio.
* **JPMorgan.SuperSimpleStocks.GBCExchangeApi** <br />
This is a basic api for providing interface to run all the required methods. You can use web browser or any application like postman to call methods in this webapi. Postman can be [downloaded](https://www.getpostman.com/) or [added](http://bit.ly/1K5ZGHG) as chrome extension.



### Design decisions.


* **Repositories:**<br />
	This project folder contains classes for Repository pattern, which is used for storing stocks and trades in memory. If in future we need to record in a file or database we can extend `IStockRespository` and `ITradeRespository` interfaces.

* **Stock**:<br />
	Project folder contains classes for Stocks. **Stock** is an Abstract class which implements `IStock` interface, it contains **PERatio** method. Classes `StockCommon` and `StockPreferred` are derived from this abstract class.<br />
 These derived classes then implements **DividendYield** abstract method by *overriding* the base class abstract method with using respective dividend yield formula for preferred and common stock.
    
* **Trade**<br />
	Project folder contains ITrade interface and its implementation Trade class which contains properties to describe trade. This class contains no method as use cases didn't identified any. <br />Method `VolumeWeightedStockPrice` seems more suitable to put outside in a service class called `Trading`.
    
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
GetVolumeWeightedStockPrice (By default price is based on trades in past 15 minutes.)
```
* **Validation**
	This class contains methods for validation, throws exceptions if valid parameters is not passed to the method in which these validation methods are being called.
* **Enums**
This contains enum for TradeType.
