# Movies Microservice

## Overview

Movies indexing application that will have high volumes of traffic. 

## Repository folders structure

Frontend

- movie-app folder -- Angular UI client 

Backend

- Movies.Contracts
- Movies.GrainClients
- Movies.Grains
- Movies.Server

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

To run the backend, run the command `dotnet run` in the repository base folder.

To run the frontend, run the following commands from within the `movie-app` folder:
1.  run the command `npm install` (to install dependencies)
2.  run the command `npm start`   (to run the application)

In your browser, navigate to `http://localhost:4200/movies`


## To contribute

1.  The backend are using deprecated libraries.
2.  Upgrade Orleans (currently at Orleans 3) 
3.  Add unit tests
4.  Add Dockerfiles for containerization.
5.  Fix bugs


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
