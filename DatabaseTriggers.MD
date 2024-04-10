## OrderDetails Tablosu

    CREATE TRIGGER DecreaseOnOrderTotalPrice
    ON UdemySignalR101Db.dbo.OrderDetails
    AFTER DELETE

    AS
    DECLARE @OrderId int
    DECLARE @Price decimal
    SELECT @OrderId = OrderId FROM DELETED
    SELECT @Price = TotalPrice FROM DELETED

    UPDATE UdemySignalR101Db.dbo.Orders SET TotalPrice = TotalPrice - @Price WHERE Id = @OrderId
    go

<br/>

    CREATE TRIGGER IncreaseOnOrderTotalPrice
    ON UdemySignalR101Db.dbo.OrderDetails
    AFTER INSERT
    AS
    DECLARE @OrderId int
    DECLARE @Price decimal
    SELECT @OrderId = OrderId FROM INSERTED
    SELECT @Price = TotalPrice FROM INSERTED

    UPDATE UdemySignalR101Db.dbo.Orders SET TotalPrice = TotalPrice + @Price WHERE Id = @OrderId
    go

<br/>

## Orders Tablosu

    CREATE TRIGGER SumCashRegisters
    ON UdemySignalR101Db.dbo.Orders
    AFTER UPDATE
    AS
    DECLARE @Status INT
    DECLARE @ORDERID INT
    DECLARE @TOTALPRICE DECIMAL(18,2)

    SELECT @Status=Status FROM INSERTED
    SELECT @ORDERID=Id FROM INSERTED
    SELECT @TOTALPRICE=TotalPrice FROM INSERTED

    IF(@Status = 1)
    BEGIN
        UPDATE UdemySignalR101Db.dbo.CashRegisters SET TotalAmount = TotalAmount + @TOTALPRICE
    END
    go

<br/>

    CREATE TRIGGER UpdateRestaurantTableAsAvailable ON UdemySignalR101Db.dbo.Orders
    AFTER UPDATE
    AS
    DECLARE @RESTAURANTTABLEID INT
    DECLARE @STATUS INT
    SELECT @RESTAURANTTABLEID=RestaurantTableId FROM INSERTED
    SELECT @STATUS=Status FROM INSERTED
    IF (@STATUS = 1)
    BEGIN
        UPDATE UdemySignalR101Db.dbo.RestaurantTables SET Status = 1 WHERE Id = @RESTAURANTTABLEID
    END
    go

    CREATE TRIGGER UpdateRestaurantTableAsOccupied ON UdemySignalR101Db.dbo.Orders
    AFTER INSERT
    AS
    DECLARE @RESTAURANTTABLEID INT
    SELECT @RESTAURANTTABLEID=RestaurantTableId FROM INSERTED

    UPDATE UdemySignalR101Db.dbo.RestaurantTables SET Status = 0 WHERE Id = @RESTAURANTTABLEID
    go
