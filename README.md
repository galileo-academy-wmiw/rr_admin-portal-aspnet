# Admin Portal ASP.NET

## Run the application

Requirements:

- .NET 8 SDK
- MySQL
- The existing `capstone_store` database

### Step 1: Open the project folder

cd AdminPortal

### Step 2: Restore the packages

dotnet restore

### Step 3: Configure the database connection

Replace the example values with your own database details:

dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=capstone_store;User=YOUR_USER;Password=YOUR_PASSWORD;"

### Step 4: Configure the admin account

- dotnet user-secrets set "AdminAccount:Username" "YOUR_ADMIN_USERNAME"
- dotnet user-secrets set "AdminAccount:Password" "YOUR_ADMIN_PASSWORD"

### Step 5: Create the Identity tables

dotnet ef database update --context AuthDbContext

### Step 6: Start the application

dotnet run

### Step 7: Log in

Open the local address shown in the terminal and log in with the configured admin account.
