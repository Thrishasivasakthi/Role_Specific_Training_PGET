CREATE DATABASE EmployeeAudit
USE EmployeeAudit

---Step 1: Create Main Table---

CREATE TABLE Employees (
EmpID INT PRIMARY KEY,
EmpName VARCHAR(100),
Department VARCHAR(50),
Salary DECIMAL(10, 2)
);

---STEP 2 : Create Audit Table---

CREATE TABLE EmployeeAuditLog (
LogID INT IDENTITY(1,1) PRIMARY KEY,
EmpID INT,
EmpName VARCHAR(100),
Department VARCHAR(50),
Salary DECIMAL(10,2),
ActionType VARCHAR(10),
ActionDate DATETIME DEFAULT GETDATE()
);

INSERT INTO Employees (EmpID, EmpName, Department, Salary) VALUES
(101, 'Alice Johnson', 'HR', 55000.00),
(102, 'Bob Smith', 'IT', 72000.50),
(103, 'Catherine Lee', 'Finance', 63500.75),
(104, 'David Miller', 'Marketing', 48000.00),
(105, 'Emma Davis', 'IT', 76000.00);

SELECT * FROM Employees

INSERT INTO EmployeeAuditLog (EmpID, EmpName, Department, Salary, ActionType) VALUES
(101, 'Alice Johnson', 'HR', 55000.00, 'INSERT'),
(102, 'Bob Smith', 'IT', 72000.50, 'INSERT'),
(103, 'Catherine Lee', 'Finance', 63500.75, 'DELETE'),
(104, 'David Miller', 'Marketing', 48000.00, 'DELETE'),
(105, 'Emma Davis', 'IT', 76000.00, 'INSERT');

SELECT * FROM EmployeeAuditLog

---Step 3: Create INSERT Trigger---

CREATE TRIGGER trg_employee_audit_log
ON Employees
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO EmployeeAuditLog(
        EmpID, EmpName, Department, Salary, ActionType, ActionDate
    )
    SELECT i.EmpID, i.EmpName, i.Department, i.Salary,  'INSERT', GETDATE() FROM INSERTED i;
END;

---Step 4: Create DELETE Trigger---

CREATE TRIGGER trg_employee_audit_log_delete
ON Employees
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO EmployeeAuditLog (
        EmpID, EmpName, Department, Salary, ActionType, ActionDate
    )
    SELECT d.EmpID,d.EmpName,d.Department,d.Salary,'DELETE',GETDATE() FROM deleted d;
END;

---Step 5: Test the Triggers---

INSERT INTO Employees (EmpID, EmpName, Department, Salary)
VALUES (201, 'Test User', 'QA', 40000.00);

SELECT * FROM EmployeeAuditLog

DELETE FROM Employees WHERE EmpID = 201;

---Step 6: Check the Audit Log---

SELECT * FROM EmployeeAuditLog WHERE EmpID = 201;

