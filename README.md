# Movies Microservice

## Contents

- Features
- General information about the app
- Provide steps how to build/launch your application

## Features

- **Home**
  - List top 5 highest rated movies

- **Movies List**
  - List Movies
  - Search
  - Filter by Genre

- **Movie detail**
  - Display selected movie detail information

- **Create Movie**
  - Create a new movie that can be retrieved in the movies list

- **Update Movie**
  - Update movies data.  
  

## Build/Launch


## Troubleshooting build/launch

1. Corrupted Microsoft.AspNetCore.App.runtimeconfig.json

Symptom:

``` txt ;Error message
A JSON parsing exception occurred in [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App\3.1.32\Microsoft.AspNetCore.App.runtimeconfig.json], offset 0 (line 1, column 1): The document is empty.
Invalid framework config.json [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App\3.1.32\Microsoft.AspNetCore.App.runtimeconfig.json]
```

Remarks:

Odds are good that the .NET SDK is corrupted.

Solution: 

Download the corresponding .NET SDK and repair it.
