-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de tabla Users
-- ==========================================================================================================================================
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL, -- 'Administrator' o 'Cliente'
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de tabla VirtualMachines
-- ==========================================================================================================================================
CREATE TABLE VirtualMachines (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    OS NVARCHAR(50) NOT NULL,
    RAM INT NOT NULL,
    CPU INT NOT NULL,
    Disk INT NOT NULL,
    Status NVARCHAR(50) NOT NULL, -- Ej. 'Running', 'Stopped', 'Suspended'
    UserId INT, -- FK a la tabla Users
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de tabla Roles
-- ==========================================================================================================================================
CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE -- Ej. 'Administrator', 'Cliente'
);
-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de tabla UserRoles
-- ==========================================================================================================================================
CREATE TABLE UserRoles (
    UserId INT,
    RoleId INT,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
