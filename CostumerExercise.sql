select 
concat(c.FirstName,' ',c.LastName) as FullName,
c.age,
o.orderId,
o.DateCreated,
o.MethodofPurchase as PurchaseMethod,
od.ProductNumber,
od.ProductOrigin
from  Customer as c inner join Orders o 
on c.PersonId = o.PersonId  inner join OrdersDetails od
on od.OrderId = o.OrderId 
where od.ProductId = 1112222333