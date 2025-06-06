CREATE DATABASE CustomerTransaction
USE CustomerTransaction

---Step 1: Table Structures---

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductName VARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10,2)
);

INSERT INTO Orders (CustomerName)
VALUES 
('Alice Johnson'),
('Bob Smith'),
('Catherine Lee'),
('David Miller'),
('Emma Davis');

SELECT * FROM Orders

INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
VALUES
(1, 'Laptop', 1, 75000.00),
(2, 'Wireless Mouse', 2, 1500.00),
(3, 'Monitor', 1, 12000.00),
(4, 'Keyboard', 3, 2000.00),
(5, 'USB Cable', 5, 300.00);

SELECT * FROM OrderItems

---Step 2: Use Transaction to Insert Data in Both Tables---

BEGIN TRANSACTION;
BEGIN
	BEGIN TRY
		
		INSERT INTO Orders (CustomerName, OrderDate)
		VALUES ('Dan Brown', '2025-06-05');

		IF @@ROWCOUNT = 0
        THROW 50001, 'Order insertion failed.', 1;

		INSERT INTO OrderItems (ProductName, Quantity, UnitPrice)
		VALUES ('Smart Phone', 4, 50000.00);

		IF @@ROWCOUNT = 0
        THROW 50001, 'OrderItems insertion failed.', 1;

		COMMIT;
		PRINT 'Transaction completed successfully';
	END TRY
	BEGIN CATCH
		ROLLBACK;
		PRINT 'Transaction rolled back due to error: ' + ERROR_MESSAGE();
	END CATCH
END

---Step 3 : Test the Transaction---

DELETE FROM OrderItems WHERE OrderID IS NULL;
DELETE FROM Orders WHERE OrderID = 9;

SELECT * FROM Orders WHERE OrderID = 10;
SELECT * FROM OrderItems WHERE OrderID IS NULL;

---Step 4: Check the Orders and OrderItems---

SELECT * FROM Orders

SELECT * FROM OrderItems