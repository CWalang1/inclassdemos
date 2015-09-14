<Query Kind="Program" />

void Main()
{
	//"Hello"+"Colton"+"World"
	//5+7
	//string name = "colton";
	//string message = "Hello" + name + "World";
	//message.Dump();
	SayHello("colton");
}

// Define other methods and classes here
public void SayHello(string name)
{
	string message = "Hello " +name+ " World";
	message.Dump();
}