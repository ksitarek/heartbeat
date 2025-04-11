## Build Targets

In the build project there is a set of targets that aim to help setting up necessary infrastructure.

| Target              | Description                                                                                                                                                                                                                            |
| ------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Clean**           | Deletes `OutputDirectory` and all `**/bin`, `**/obj` directories recursively                                                                                                                                                           |
| **Restore**         | Runs `dotnet restore` for entire solution.                                                                                                                                                                                             |
| **Compile**         | Runs `dotnet build` for entire solution.                                                                                                                                                                                               |
| **RunPostgres**     | Starts PostgreSQL server in Docker. When server is online, **MigrateDatabase** is triggered.                                                                                                                                           |
| **MigrateDatabase** | Runs migration against database. <br><br>Database configuration is retrieved from Heartbeat.API/appsettings.json file. <br><br>Test data will be loaded to _TestClientId_ database if optional --load-test-data parameter is provided. |
|                     |                                                                                                                                                                                                                                        |
### RunPostgres
```mermaid
graph LR
	RunPostgres --> MigrateDatabase
```

### Compile
```mermaid
graph LR
	Clean --> Restore
	Restore --> Compile
```