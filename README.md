# ReminderHub_WorkerService

Welcome to the README file for your project! Here are the instructions to set up and configure the project:

## Configuration

1. Open the `appsettings.json` file located in the project root directory.

2. Locate the `DefaultConnection` key and update its value with your desired database connection string.

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "your_connection_string_here"
     }
   }
   
### 2. Update ReminderDbContext

Next, navigate to the `DataAccess` folder in the project. Inside the `Concrete` folder, you will find the `EntityFramework` folder. Open the `ReminderDbContext.cs` file.

In the `ReminderDbContext` class, locate the constructor that accepts a `DbContextOptions<ReminderDbContext>` parameter. Inside the constructor, you will find the configuration for the database connection. Update the configuration to match your database settings.

```csharp
public class ReminderDbContext : DbContext
{
    public ReminderDbContext(DbContextOptions<ReminderDbContext> options)
        : base(options)
    {
        // Update database connection configuration here
    }

    // DbSet properties and other configurations
    ...
}

