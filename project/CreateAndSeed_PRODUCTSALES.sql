CREATE TABLE PRODUCTSALES (
    SaleID INT PRIMARY KEY,
    ProductCode NVARCHAR(10),
    ProductName NVARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10,2),
    SaleDate DATE
);

INSERT INTO PRODUCTSALES (SaleID, ProductCode, ProductName, Quantity, UnitPrice, SaleDate)
VALUES
(1, 'P001', 'Pen', 10, 1.50, '2025-06-20'),
(2, 'P001', 'Pen', 5, 1.50, '2025-06-25'),
(3, 'P002', 'Notebook', 3, 3.20, '2025-06-21'),
(4, 'P003', 'Eraser', 15, 0.80, '2025-06-22');
