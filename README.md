# Admin Portal ASP.NET

## Run the application

Requirements:

- .NET 8 SDK
- MySQL

### Step 1: Create and seed the database

mysql -u root -p -e "CREATE DATABASE capstone_store;"

mysql -u root -p capstone_store < database/schema.sql

mysql -u root -p capstone_store < database/seed.sql

### Step 2: Open the project folder

cd AdminPortal

### Step 3: Restore the packages

dotnet restore

Install the EF Core tool if it is not already installed:

dotnet tool install --global dotnet-ef --version 8.0.16

### Step 4: Configure the database connection

Replace the example values with your own database details:

dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=capstone_store;User=YOUR_USER;Password=YOUR_PASSWORD;"

### Step 5: Configure the admin account

The password must be at least 6 characters long and contain an uppercase letter, a lowercase letter, a number, and a special character.

- dotnet user-secrets set "AdminAccount:Username" "YOUR_ADMIN_USERNAME"
- dotnet user-secrets set "AdminAccount:Password" "YOUR_ADMIN_PASSWORD"

### Step 6: Create the Identity tables

dotnet ef database update --context AuthDbContext

### Step 7: Start the application

dotnet run

### Step 8: Log in

Open the local address shown in the terminal and log in with the configured admin account.
