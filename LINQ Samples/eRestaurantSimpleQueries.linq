<Query Kind="Statements">
  <Connection>
    <ID>9e0452c6-e2ad-4cd7-9c8c-81b5b529add4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Step1 Connect to the desired database 
	//Click on add connection 
	//take defaults press next 
	//change server to . (dot) select existing database from drop down list 
	//optionally press test connection 
	//press ok 
	//remember to check the connection drop down list to see which database is the active connection 
	
	//result should show database tables in connection object area 
	//expanding a table will reveal the table attributes and any relationships 
	
	//view waiter data 
	Waiters
	
	//query syntax to also view Waiter data 
	from item in Waiters
	select item 
	
	//method syntax to view Waiter data
	Waiters.Select (item => item)
	
	//alter the query syntax into a C# Statement 
	var results = from item in Waiters 
					select item; 
	results.Dump();
	
	//once the query is created, tested you will be able to 
	//transfer the query with minor modifications into your 
	//BLL methods 
	//public List<pcoObject> SomeBLLMethodName()
	//{
		//connect to your DAL object : var contextvariable
		//do your query 
		//var results = from item in contextvariable.Waiters 
		//		select item; 
		//return results.ToList();
		
	//}
	