USE B_DB14_2018
GO

ALTER VIEW AllOrderLines
AS
SELECT ol.Order_Id, cust.FName, cust.LName, ord.Order_Date, prod.Prod_Name, prod.Price, ol.Amount
FROM
    EX62_OrderLine AS ol
    JOIN EX62_Order AS ord
        ON ol.Order_Id = ord.Order_Id
    JOIN EX62_Customer AS cust
        ON ord.Customer = cust.Customer_Id
    JOIN EX62_Product AS prod
        ON ol.Product_Id = prod.Product_Id
GO