## Build Targets

In the build project there is a set of targets that aim to help setting up necessary infrastructure.

| Target                  | Description                                                                                                                                                                   |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Clean**               | Deletes `OutputDirectory` and all `**/bin`, `**/obj` directories recursively                                                                                                  |
| **Restore**             | Runs `dotnet restore` for entire solution.                                                                                                                                    |
| **Compile**             | Runs `dotnet build` for entire solution.                                                                                                                                      |
| **RunPostgres**         | Starts PostgreSQL server in Docker. When server is online, **MigrateAllDatabases** is triggered.                                                                              |
| **MigrateAllDatabases** | Runs migration against all configured databases. Db configuration is retrieved from Heartbeat.API/appsettings.json file. Test data will be loaded to _TestClientId_ database. |
|                         |                                                                                                                                                                               |
### RunPostgres
```mermaid
graph LR
	RunPostgres --> MigrateAllDatabases
```

### Compile
```mermaid
graph LR
	Clean --> Restore
	Restore --> Compile
```