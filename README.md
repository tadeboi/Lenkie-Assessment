# Lenkie-Assessment
Lenkie Library Assessment Solution

- A Simple Online Library Implementation
- Built with .NET Core 6 and MS SQL Server

**Steps to Run**
- Pull the the code into your Visual Studio; make sure you have .NET Core 6 installed on your system/server 
- Go to appsettings.json and change the "LibraryAPIConnectionString" value to your preferred MS SQL Server Database URL
- Run your EF Core Migrations in your console to "Add-Migration" and "Update-database"
- You can then run it like that. However, to run it with OpenIDConnect OAuth:
  1 - Go to the Program class and uncomment the commented code and then replace the names in the curly bracelets {} with actual OpenIDConnect details
          options.Authority = "{IdentityServerURL}";
          options.ClientId = "{ClientId}";
          options.ClientSecret = "{ClientSecret}";
  2 - Go to the 2 Controller Classes and uncomment the [Authorize] Attribute at the top of the Controller classes.
  3 - You can now run the solution.


*Shalom*
  
