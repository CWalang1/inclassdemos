<Query Kind="Expression">
  <Connection>
    <ID>9e0452c6-e2ad-4cd7-9c8c-81b5b529add4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//where clause 

//list all tables that hold more than 3 people 
from row in Tables 
where row.Capacity > 3 
select row 

//list all items with more than 500 calories and sells for more than
//$10 
from foodies in Items 
where foodies.Calories > 500  &&
	foodies.CurrentPrice > 10.00m
select foodies 

//list all items with more than 500 calories and 
//are Entrees on the menu 
//HINT: the navigational properties of the database and LINQpad's knowledge 
from foodies in Items 
where foodies.Calories > 500 && 
	  foodies.MenuCategory.Description.Equals("Entree")
select foodies


