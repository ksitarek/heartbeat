# 🫀 Heartbeat

**Heartbeat** is a tool for monitoring the health of your applications. It makes it easy to check if your services are alive and alerts you when something goes wrong — so you can react and fix it fast.

## 🚀 Getting Started

Follow these steps to get up and running:

### 1. Clone the repository

```bash
git clone https://github.com/ksitarek/heartbeat.git
cd heartbeat
```

### 2. Build the project

Use [nuke](https://nuke.build/) to compile the solution:

```bash
nuke Compile
```

### 3. Provision the DB

The easiest approach you can take is to use `nuke RunPostgres` to set up a PostgreSQL database on Docker.

If you don't want to use Docker, you can configure PostgreSQL connection in `src/backend/Heartbeat.API/appsettings.json` file. After that, you can call `nuke MigrateAllDatabases` to trigger DB migration and to load test data into the DB.

### 3. Run the app

Start the API by running the compiled DLL:

```bash
dotnet out/Heartbeat.API.dll
```

## 📚 Documentation

Documentation lives in the `/docs` folder and is managed with [Obsidian](https://obsidian.md). You can open that folder as an Obsidian vault to browse, edit, or contribute.
