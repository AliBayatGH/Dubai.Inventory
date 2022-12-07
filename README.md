## Test case:

**The goal is to create an inventory with** :
- Products
- Name
- Barcode
- Description
- Category name
- Weighted or Non Weighted
- Product Status (**Sold**, **InStock**, **Damaged**)

Using **DDD**, **SQL server**, **EF Core** for the database provider, **.NET Core**, *No UI needed*.
Create 3 APIs:
1) Count the number of products **Sold**, **Damaged** and **InStock**
2) Change the status of a product
3) Sell a product

Make sure you have installed **.NET 7** in your environment. After that, you can run the below commands from the **Dubai.Inventory.Api** directory.

    dotnet run
    
### Dependencies

* .NET 7
* SQL Server

### Executing program

* Download & Install **.NET 7** from [here](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* Configure connection strings
* Run the project

    dotnet run

### Integration tests dependencies
    docker pull testcontainers/ryuk:0.3.4
    docker pull mcr.microsoft.com/mssql/server:2022-latest
