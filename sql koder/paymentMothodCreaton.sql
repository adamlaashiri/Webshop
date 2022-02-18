-- Shipping method rows creation
USE webshop
GO

Declare @fedexPayment as SMALLMONEY = 120.0
Declare @postnordPayment as SMALLMONEY = 50.0


Insert INTO ShippingMethods(Name, Price) VALUES('Fedex', @fedexPayment), ('Postnord', @postnordPayment)