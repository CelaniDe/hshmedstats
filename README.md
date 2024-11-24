## Prerequisites

Ensure you have the following installed:

- **Docker** (for containerized environment)
- **.NET 8.1SDK**  
- **Entity Framework Core CLI** (optional, for migrations)  

## Setup Instructions

Follow these steps to set up the project on your local machine:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/CelaniDe/hshmedstats.git
   ```

2. **Navigate to the project directory:**
   ```bash
   cd hshmedstats
   ```

3. **Start Docker containers for Postgresql:**
   ```bash
   docker compose up -d
   ```

4. **Restore NuGet packages:**
    ```bash
    cd src
    dotnet restore
    ```

5. **Database setup:**
    ```bash
    cd Web
    dotnet-ef database update // for linux is : dotnet ef database update
    ```

## Running the Application

1. **Navigate to the Web project folder:**
   ```bash
   cd Web/
   ```
2. **Navigate to the Web project folder:**
   ```bash
   dotnet run
   ```

## Contributing

The default branch is **master**
