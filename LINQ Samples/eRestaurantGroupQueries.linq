<Query Kind="Expression">
  <Connection>
    <ID>9e0452c6-e2ad-4cd7-9c8c-81b5b529add4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//grouping 
from food in Items 
group food by food.MenuCategory.Description

//requires the creation of an anonymous type 
from food in Items 
group food by new {food.MenuCategory.Description, food.CurrentPrice}