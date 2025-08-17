USE CompanyDB;
GO

-- Create Tables
CREATE TABLE Departments (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentID)
        REFERENCES Departments(DepartmentID)
);

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL
);

CREATE TABLE EmployeeProjects (
    EmployeeID INT NOT NULL,
    ProjectID INT NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_EmployeeProjects PRIMARY KEY (EmployeeID, ProjectID),
    CONSTRAINT FK_EmployeeProjects_Employees FOREIGN KEY (EmployeeID)
        REFERENCES Employees(EmployeeID),
    CONSTRAINT FK_EmployeeProjects_Projects FOREIGN KEY (ProjectID)
        REFERENCES Projects(ProjectID)
);
GO

-- Create Indexes
CREATE INDEX IX_Employees_DepartmentID ON Employees (DepartmentID);
CREATE INDEX IX_EmployeeProjects_ProjectID ON EmployeeProjects (ProjectID);
GO

-- Sample Data
INSERT INTO Departments (Name) VALUES
('Engineering'),
('Marketing'),
('Finance');

INSERT INTO Employees (FirstName, LastName, DepartmentID) VALUES
('John', 'Doe', 1),
('Jane', 'Smith', 1),
('Mike', 'Johnson', 2),
('Sarah', 'Williams', 3);

INSERT INTO Projects (Name, StartDate, EndDate) VALUES
('Website Redesign', '2023-01-15', '2023-06-30'),
('Mobile App Development', '2023-02-01', NULL),
('Financial System Upgrade', '2023-03-10', '2023-12-15');

INSERT INTO EmployeeProjects (EmployeeID, ProjectID, Role) VALUES
(1, 1, 'Lead Developer'),
(1, 2, 'Architect'),
(2, 1, 'Frontend Developer'),
(2, 2, 'Backend Developer'),
(3, 1, 'UX Designer'),
(4, 3, 'Project Manager');
GO