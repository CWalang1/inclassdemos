<Query Kind="Expression">
  <Connection>
    <ID>9e0452c6-e2ad-4cd7-9c8c-81b5b529add4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//orderby 

//default ascending 
from food in Items 
orderby food.Description 
select food 

//default descending 
from food in Items 
orderby food.CurrentPrice  descending 
select food 

//default descending and ascending 
from food in Items 
orderby food.CurrentPrice  descending, food.Calories ascending 
select food 

//default descending and ascending 
from food in Items 
where food.MenuCategory.Description.Equals("Entree")
orderby food.CurrentPrice  descending, food.Calories ascending 
select food 
