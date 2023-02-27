# _Burrito Boys Api_

#### By: _**David Gamble**_

#### _Epicodus project to demonstrate building an API and using swagger to test end points._

## Technologies Used

* _C#_
* _.NET 6_
* _ASP.NET Core MVC 6_
* _Entity Framework Core_
* _MySql_
* _Swagger_

### Description

_Description here._

## Setup/Installation Requirements

* _Clone the repository to your desktop from: [GITHUB REPO]_
* _Create appsettings.json file in BurritoBoysApi folder_
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE_NAME];uid=[USERNAME];pwd=[PASSWORD];"
  }
}
```
* _run dotnet commands below in BurritoBoysApi folder_
```
dotnet restore
```
```
dotnet ef database update
```
```
dotnet watch run
```
* _dotnet watch run will open the swagger ui where you can test the endpoints or you can alternatively use PostMan_
------------------------------

## API Documentation

### Using Swagger Documentation 

* To explore the Animal Shelter Api with Swagger, launch the project using `dotnet watch run` with the Terminal or Powershell.
* In the upper right corner of the Swagger UI select the version you would like to use.

### Endpoints
Base URL: `https://localhost:5000`

#### HTTP Request Structure
```
GET /api/v1/{component}
POST /api/v1/{component}
GET /api/v1/{component}/{id}
PUT /api/v1/{component}/{id}
DELETE /api/v1/{component}/{id}
```

#### Example Query
```
https://localhost:5000/api/v1/Dogs/1
```

#### Sample JSON Response
```
{
  "dogId": 1,
  "name": "Taco",
  "age": 9,
  "breed": "Pitbull"
} 
```

#### Example Query
```
https://localhost:5000/api/v1/Cats?name=bella
```

#### Sample JSON Response
``` 
{
  "catId": 3,
  "name": "Bella",
  "age": 6,
  "breed": "Tabby Cat"
}
```

#### HTTP Request Structure for V2
```
GET /api/v2/{component}
```

#### Example Query
```
https://localhost:5000/api/v2/Cats
```

#### Sample JSON Response
``` 
{
  "catId": 1,
  "name": "Moonbeam",
  "age": 8,
  "breed": "Maine Coon"
}
```

## Known Bugs

* _No known bugs._

## License

_Copyright (c) 2022 David Gamble_

_Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:_

_The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software._

_THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._
