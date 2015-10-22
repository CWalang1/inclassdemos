<Query Kind="Expression">
  <Connection>
    <ID>9e0452c6-e2ad-4cd7-9c8c-81b5b529add4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from abillrow in Bills 
where abillrow.BillDate.Month == 5 
orderby abillrow.BillDate, abillrow.Waiter.LastName, abillrow.Waiter.FirstName 
select new 
{
	BillDate = new DateTime(abillrow.BillDate.Year, 
							abillrow.BillDate.Month,
							abillrow.BillDate.Day),

	Name = abillrow.Waiter.LastName + ", " + abillrow.Waiter.FirstName,
	BillID = abillrow.BillID,
	BillTotal = abillrow.BillItems.Sum(bitem => bitem.Quantity * bitem.SalePrice),
	PartySize = abillrow.NumberInParty,
	Contact = abillrow.Reservation.CustomerName
}