# Academy Task - Backend

The given task was to create a C# middleware with the
capability of fetching data from various sources. Fetching data is done by implementing `IProductService` interface 
and can be generalized and implemented through the Dependancy injection. The API
implements authentication using JWT. The REST
API implements the following endpoints:
### Products
1. `POST: /api/Products/postProducts` - Populates the database with products
2. `GET: /api/Products` - Retrieves all products from the database
3. `GET: /api/Products/{id}` - Retrieves a product with a specific id
4. `GET: /api/Products/search` - Retrieves every product whose name contains the queried string
5. `GET: /api/Products/filter` - Retrieves every product that matches user chosen category and price conditions

### User
1. `POST: /api/Users/register` - Registers a new user
2. `POST: /api/Users/login` - Used for user login. Issues a JWT.

The API also implements three protected endpoints accessible only
with a valid JWT:
1. `GET: /api/Products/favorite` - Retrieves all products the authorised user liked
2. `POST: /api/Products/favorite/{productId}` - Adds a new liked product to the user
3. `DELETE: /api/Products/favorite/{productId}` - Removes a liked product

All of the endpoints are can be tested at `localhost:<xxxx>/swagger` once the application
is set up and running.

## Setup

### Prerequisites
- .NET 9 SDK
- PostgreSQL

### Procedure

1. Clone the repository

2. Set up the `.env` file based on the `.env.example`file

3. Open the project in Visual Studio/Rider and in terminal change the working directory
```
cd AcademyTask.Infrastructure
```
4. Run the command 
```
dotnet ef database update
```
5. Change working directory to `AcademyTask.Api` and run:
```
dotnet run
```
6. Open the `localhost:<xxxx>/swagger` link to track all of the endpoins in Swagger UI. To test the protected `/favorite` endpoints, register a user, log in to
   receive a JWT, then click "Authorize" in Swagger UI and paste the token. Before testing, populate the database by calling the postProducts endpoint
7. To run the provided tests, change working directory to `AcademyTask.Test` and run the command
```
dotnet test
```

### Author notes

Most of the code used for this project was refactored from my
previous projects [Internship-4-OOP2](https://github.com/josipzunic/Internship-4-OOP2) and 
[Internship-7-Moodle](https://github.com/josipzunic/Internship-7-Moodle). Claude AI was
used mostly for debugging and explaining unknown terms and concepts. Claude also
helped with file organization and helped me build most of the JWT related code since 
I haven't had prior experience with that type of authorization.


*Example prompt*

Q: Razmislite kako biste riješili ako korisnik više puta poziva endpoint pretrage ili filtriranja proizvoda s istim parametrima this is one of the points in the assigment. why is that a problem?


