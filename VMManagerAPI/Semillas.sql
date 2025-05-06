-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de semillas Roles
-- ==========================================================================================================================================
INSERT INTO Roles (Name) VALUES
('Administrator'),
('Cliente');
-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de semillas Users
-- ==========================================================================================================================================
INSERT INTO Users (Email, PasswordHash, Role, CreatedAt, UpdatedAt) VALUES
('admin@example.com', '$2a$12$1jjBE6pB.FZcgipHhYNZFu2c79vqxqLKumBAv5iU9fxHQUijSvbNC', 'Administrator', GETDATE(), GETDATE()),
('cliente1@example.com', '$2a$12$nW9I8xneQHQYE6F51EpCAO6E5V87Isns9bNr1pFBKnk5qjwPJNsUO', 'Cliente', GETDATE(), GETDATE());
-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de semillas UserRoles
-- ==========================================================================================================================================
INSERT INTO UserRoles (UserId, RoleId) VALUES
(1, 1),
(2, 2);
-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de semillas VirtualMachines
-- ==========================================================================================================================================
INSERT INTO VirtualMachines (Name, OS, RAM, CPU, Disk, Status, UserId, CreatedAt, UpdatedAt) VALUES
('VM-WinServer', 'Windows Server 2019', 8192, 4, 100, 'Running', 1, GETDATE(), GETDATE()),
('VM-Ubuntu', 'Ubuntu 22.04', 4096, 2, 50, 'Stopped', 2, GETDATE(), GETDATE()),
('VM-CentOS', 'CentOS 8', 2048, 2, 60, 'Running', 2, GETDATE(), GETDATE());
-- ==========================================================================================================================================
-- Descripción de actualización
-- Cuando      Quien                        Que
-- ==========  =========================    =================================================================================================
-- 05/04/2025  Pedro Castro                  Creacion de semillas Users
-- ==========================================================================================================================================
INSERT INTO Users (Email, PasswordHash, Role, CreatedAt, UpdatedAt) VALUES
('admin@example.com', 'hashed_admin_password', 'Administrator', GETDATE(), GETDATE()),
('cliente1@example.com', 'hashed_cliente1_password', 'Cliente', GETDATE(), GETDATE());