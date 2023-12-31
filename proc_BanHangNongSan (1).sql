CREATE PROCEDURE GetCurrentMonthRevenue
AS
BEGIN
    DECLARE @CurrentMonth INT, @CurrentYear INT;
    SET @CurrentMonth = MONTH(GETDATE());
    SET @CurrentYear = YEAR(GETDATE());

    SELECT ISNULL(SUM(order_total_value), 0) AS CurrentMonthRevenue
    FROM user_order
    WHERE MONTH(order_time) = @CurrentMonth AND YEAR(order_time) = @CurrentYear;
END
exec GetCurrentMonthRevenue
go
CREATE PROCEDURE GetCurrentMonthBefore
AS
BEGIN
    DECLARE @BeforeMonth INT, @CurrentYear INT;
    SET @BeforeMonth = MONTH(GETDATE()) - 1;
    SET @CurrentYear = YEAR(GETDATE());

    SELECT ISNULL(SUM(order_total_value), 0) AS CurrentMonthRevenue
    FROM user_order
    WHERE MONTH(order_time) = @BeforeMonth AND YEAR(order_time) = @CurrentYear;
END
exec GetCurrentMonthBefore

go
CREATE PROCEDURE GetCurrentYearlyRevenue
AS
BEGIN
    DECLARE  @CurrentYear INT;
    SET @CurrentYear = YEAR(GETDATE());

    SELECT ISNULL(SUM(order_total_value), 0) AS CurrentYearRevenue
    FROM user_order
    WHERE YEAR(order_time) = @CurrentYear;
END

exec GetCurrentYearlyRevenue

CREATE PROCEDURE GetMonthlyRevenue
AS
BEGIN
    SELECT MONTH(order_time) AS Month, SUM(order_total_value) AS Revenue
    FROM user_order
    GROUP BY MONTH(order_time)
END