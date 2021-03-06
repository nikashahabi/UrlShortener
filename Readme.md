
# UrlShortener with .NET Core

This project is a simple *URLshortener* implemented with .NET Core Framework and uses powerful Entity Framework as its *ORM* to fetch data from Postgres Database. It encodes valid long URLs to short ones and can redirect to a long URL after getting the corresponding short URL.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

You need to have Postgres installed. Clone the project execute the following commands in src directory.

1. This will add new migration files.

```bash
dotnet ef migrations add urlshortener.DbMig1
```

2. This command will update database created by migration.

```bash
dotnet ef database update
```



### Building and Running

1. Change to the src directory. (i.e. `./src`)
2. To get all *NuGet* Packages needed execute the following command.

```
dotnet restore
```

3. Build and run with the following commands:
```bash
dotnet build
dotnet run
```



## Controllers Explanation

Two classes exist in MainController, one implement Post action and the other implement Get action.

After running the project you can usually get data from http://localhost:5000 or http://localhost:5001 but it may be different based on your system config.

1. **Post**: The post action gets a long URL in a format of a *JSON* and checks to see if it's a valid URL. In the case of validation, it generates a short URL which is a stirng of length 8 consisting of only lower and upper case. If the long URL is not valid the request status will be 400.  http://localhost:5000/urls

   ```json
   {
     "longUrl": "www.google.com"
   }
   ```

With the response being something like the following:

   ```json
   {
     "longUrl": "www.google.com",
     "shortUrl": "abcdABCD"
   }
   ```

   2. **Get**: The Get action runs on http://localhost:5000/redirect/abcdABCD and redirects to the corresponding long URL. If the given short URL does't exist in the Postgres database request status will be 404.