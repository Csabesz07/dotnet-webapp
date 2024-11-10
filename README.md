# A student registry using dotnet and angular

In order for the application to run seemlessly, you have to run both the backend and the frontend simultaneously.
The page is capable of

- Basic authorization
  - Two rights are defined, these are the `read` and `write`
  - You can login with any account, but only one has write right and that's the one with the credentials on the login page
- Student list
- Student statistics list
- Student registration
- Grade assignment
- Internationalization
  - English
  - Hungarian

## Frontend

The frontend was made with `Angular v17`.
In order to start the project `clone the reposity`, go into the **frontend** folder and sequentially give the following commands:

```
1) npm i
2) npm start
```

The frontend is optimized for 3 screen sizes, these are: `mobile`, `laptop` and `desktop`.
The components used in the application are sourced from `Bootstrap component library`.

## Backend

The backend uses `.NET8 LTS` version.
The database was created with Entity Framework to achive a code-first database structure.
In order to run the backend, you have to set the **Core** project as a startup project as this is where all the startup logic is defined.
The database is regenerated each time the application starts, due to the use of `SqlLite in-memory` database provider.
The authorization uses the standard authorization option provided by [ASP.NET](ASP.NET)
