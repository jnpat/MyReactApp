DB_Diagram
![DB_Diagram](https://github.com/user-attachments/assets/648a67ef-6be6-48c2-8a82-b257b9d3ff03)

To Run App
1. Create DB as Shop_DB
2. Run SQL script
3. Scaffold MySQL Database with EF Core with
```powershell
dotnet ef dbcontext scaffold "Server=.\;Database=Shop_DB;Trusted_Connection=true;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context ShopDbContext --no-build
```
4. Run App

UI
![UI](https://github.com/user-attachments/assets/388240a6-b037-4952-ba34-423d31dfac1c)
