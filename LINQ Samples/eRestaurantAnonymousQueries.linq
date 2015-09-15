<Query Kind="Expression">
  <Connection>
    <ID>9e0452c6-e2ad-4cd7-9c8c-81b5b529add4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//anonymous type 
from food in Items 
where food.MenuCategory.Description.Equals("Entree") && 
		food.Active
orderby food.CurrentPrice descending 
select new 
		{
			Description = food.Description, 
			Price = food.CurrentPrice, 
			Cost = food.CurrentCost, 
			Profit = food.CurrentPrice - food.CurrentCost
		}
		
//anonymous type without the labels 
from food in Items 
where food.MenuCategory.Description.Equals("Entree") && 
		food.Active
orderby food.CurrentPrice descending 
select new 
		{
			food.Description, 
			food.CurrentPrice, 
			food.CurrentCost, 
			//Profit = food.CurrentPrice - food.CurrentCost
		}
		