# Final-Project — Console Employee Management (EF Core + SQL Server)

A simple **console app** in C# using **Entity Framework Core (Code First)** with **Microsoft SQL Server**.  
Manage **Departments**, **Employees**, and **Projects** with:

- Department (1) → Employee (Many)
- Project (Many) ↔ Employee (Many)

---

## ✨ Features

- **Add**
  - Employee
  - Department
  - Project
- **Edit**
  - Employee data
  - Assign Employee to Department
  - Assign/Remove Employee to/from Project
  - Update Department / Project data
- **Delete**
  - Employee
  - Department
  - Project
- **Display**
  - Employee (with Department & Projects)
  - Department (with Employees)
  - Project (with Employees)

---

## 🧱 Tech Stack

- .NET 6+ (tested on .NET 8)
- Entity Framework Core (Code First)
- Microsoft SQL Server
- Console UI

---

## 📁 Project Structure

```

Final-Project/
│
├─ Program.cs
├─ AppDbContext.cs
│
├─ Models/
│  ├─ Department.cs      // DepartmentId, Name, Employees
│  ├─ Employee.cs        // EmployeeId, FullName, DepartmentId, Department, Projects
│  └─ Project.cs         // ProjectId, Title, Employees
│
└─ Services/
└─ MenuActions.cs     // All menu & CRUD logic

````

---

## ⚙️ Setup

### 1) Requirements
- **.NET SDK** 6 or newer
- **SQL Server** (LocalDB, Express, or full)
- (Optional) **SSMS** for database management

### 2) Install NuGet packages (Package Manager Console)
```powershell
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
````

> If you hit a version mismatch (NU1605), align EF packages to the same version:
>
> ```powershell
> Update-Package Microsoft.EntityFrameworkCore -Version 9.0.8
> Update-Package Microsoft.EntityFrameworkCore.SqlServer -Version 9.0.8
> Update-Package Microsoft.EntityFrameworkCore.Tools   -Version 9.0.8
> ```

### 3) Configure the connection string (`AppDbContext.cs`)

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer(
        "Server=(localdb)\\MSSQLLocalDB;Database=ProjectDB;Trusted_Connection=True;TrustServerCertificate=True;");
}
```

**Other examples:**

* SQL Express: `Server=.\SQLEXPRESS;Database=ProjectDB;Trusted_Connection=True;TrustServerCertificate=True;`
* SQL Auth: `Server=localhost;Database=ProjectDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;`

### 4) Create DB via EF Migrations

```powershell
Add-Migration InitialCreate
Update-Database
```

> If **Build failed** appears, build the solution to see errors. Common fix:
> add `using Microsoft.EntityFrameworkCore;` at the top of files that use `.Include(...)`.

---

## ▶️ Run

* **F5** in Visual Studio **or**
* `dotnet run` in the project directory

You’ll get a text menu to add/edit/delete/display data and manage assignments.

---

## 🌱 Sample Data (optional)

Prefer using the app’s menu to add data. If you want quick SQL inserts in SSMS:

```sql
USE ProjectDB;

-- Departments
INSERT INTO Departments (Name) VALUES
('HR'),
('IT'),
('Finance');

-- Projects
INSERT INTO Projects (Title) VALUES
('Website Redesign'),
('Mobile App'),
('Cloud Migration');

-- Employees
INSERT INTO Employees (FullName, DepartmentId) VALUES
('Nourin', 1),
('Alice', 1),
('Bob', 1),
('Charlie', 2);

-- Join table (EF Core auto-created)
-- Check actual join table + columns first:
-- SELECT TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME LIKE '%Employee%';

-- Typical EF naming for many-to-many:
--   Table: EmployeeProject
--   Columns: EmployeesEmployeeId, ProjectsProjectId
INSERT INTO EmployeeProject (EmployeesEmployeeId, ProjectsProjectId) VALUES
(2, 2),  -- Alice → Website Redesign
(3, 3),  -- Bob   → Mobile App
(4, 4);  -- Charlie → Cloud Migration
```

> If the join column names differ on your machine, run:
>
> ```sql
> SELECT TABLE_NAME, COLUMN_NAME
> FROM INFORMATION_SCHEMA.COLUMNS
> WHERE TABLE_NAME LIKE '%Employee%' OR TABLE_NAME LIKE '%Project%';
> ```
>
> …and adjust the insert accordingly.

---

## 📤 Exporting Your SQL Server Database

**Option A — Backup file (`.bak`):**

1. SSMS → right-click `ProjectDB` → **Tasks → Back Up…**
2. Choose a path and click **OK** → produces `ProjectDB.bak`.

**Option B — Script schema + data (`.sql`):**

1. SSMS → right-click `ProjectDB` → **Tasks → Generate Scripts…**
2. Script entire DB → **Advanced** → *Types of data to script* = **Schema and Data** → Save.

**Option C — Detach/Attach files:**

* Detach DB, then copy `ProjectDB.mdf` and `ProjectDB_log.ldf` from the SQL data folder, and attach on the target machine.

---

## 🔄 (Optional) Switch to SQLite (single `.db` file)

Install provider and change context:

```powershell
Install-Package Microsoft.EntityFrameworkCore.Sqlite
```

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source=ProjectDB.db");
}
```

Then recreate the DB:

```powershell
Add-Migration InitialCreate -Force
Update-Database
```

---

## 🛠️ Troubleshooting

* **NU1605 package downgrade:** align EF package versions (see Setup).
* **`.Include()` not found:** add `using Microsoft.EntityFrameworkCore;`.
* **Migrations fail with “Build failed”:** build solution and fix compile errors first.
* **FK conflict inserting into join table:** ensure referenced `EmployeeId` / `ProjectId` exist.

---

## 📜 License

Educational/demo purposes. Use freely in coursework/projects.

```
```
