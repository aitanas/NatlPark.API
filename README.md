# National Parks API

#### By Aitana Shough

An API created for US national and state park information.

## Technologies Used

* C#
* .Net 6
* ASP.Net EF Core 6
* SQL
* LINQ
* Newtonsoft

## Setup/Installation Requirements

#### To run this project, you will need:
* .NET 6.0
[https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)

* .NET Core CLI
```
dotnet tool install --global dotnet-ef --version 6.0.0
```

1. Clone this repo to your workspace.

2. Navigate to the `ParkApi` directory.

3. Create a file named `appsettings.json` with the following code. Be sure to update the Default Connection to your MySQL credentials.
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=natl_parks;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];",
  }
}
```

4. Create database on your local machine via Migrations
```
dotnet ef database update
```

5. Install dependencies within the `ParkApi` directory
```
$ dotnet restore
````

6. Build and run the program 
 ```
 $ dotnet run
 ```

7. Enjoy!


## Endpoints

```
GET http://localhost:5000/api/parks/
GET http://localhost:5000/api/parks/{id}
POST http://localhost:5000/api/parks/
PUT http://localhost:5000/api/parks/{id}
DELETE http://localhost:5000/api/parks/{id}
```

|Parameter | Type | Required (Y/N) | Description |
|----------|------|----------------|-------------|
|name      |string| N              |Returns parks with a matching name value|
|state     |string| N              |Returns parks located in the specified state. States are currently searchable using their two letter abbreviation (ex. OR, WA)|
|climate   |string| N              |Returns parks based on their climate/biome. See list of biomes below.|
|dogFriendly|string|N              |Returns parks based on whether they are dog friendly (Y) or not (N).|

### Climate Terminology Guide

The `climate` parameter is standardized based on terrestrial biome terminology.

![A diagram of terrestrial biomes, used as a guide for the API climate parameter.](https://pbs.twimg.com/media/FNA1yWyWYAYOjIz?format=jpg&name=900x900 "Terrestrial Biomes")

A list of valid parameters is as follows:

|  |Hot        |Moderate     |Cold                  |
|----------------|-----------|-------------|----------------------|
|**Dry**         |Desert     |Desert      |Tundra                |
|**Temperate**   |Plains  |Deciduous Forest |Coniferous Forest |
|**Wet**    |Tropical Rainforest |Temperate Rainforest | |

### Pagination

This API utilizes **pagination**, with code adapted from [this tutorial] (https://code-maze.com/paging-aspnet-core-webapi/). Pagination, or paging, splits up entries to avoid queries that return the entire database. 

The number of entries per page is currently set to 2. If desired, the number of entries may be modified via the `Models/Common/Parameters.cs` file:

```
    const int maxPageSize = 2; // max amount of elements per page
    public int PageNumber { get; set; } = 1; // how many pages you will have ( Number of elements / maxPageSize )
    private int _pageSize = 2; // works in relation with public PageSize, if not specified default 3 elements will populate
    public int PageSize // this property value represents how many elements you want to show in a Get
```

## Further Goals

* Make states searchable by both abbreviation and state name
* Add additional parameters relating to parks
* Add more national and state park seed data


## Known Bugs

* No known bugs.


## License

**MIT License**

Copyright (c) 2023 Aitana Shough

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
