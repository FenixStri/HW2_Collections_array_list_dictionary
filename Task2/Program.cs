// Fenix Strickland
// MIS 3033 Task 2


Dictionary<string, double> Fruits = new Dictionary<string, double>();
Fruits.Add("apples", 0.99);
Fruits.Add("oranges", 0.50);
Fruits.Add("bananas", 0.50);
Fruits.Add("grapes", 2.99);
Fruits.Add("blueberries", 1.99);

foreach (KeyValuePair<string, double> Fruit in Fruits)
{
    Console.WriteLine("Key:{0}", Fruit.Key);
}
    
Console.WriteLine("Please input the item name you want to show the price:");
string userInput = Console.ReadLine();

if (Fruits.ContainsKey(userInput))
{
    Console.WriteLine($"The price for {userInput} is {Fruits[userInput]:c2}");
}

else
{
    Console.WriteLine("Item Name Input Error!");
}

Console.ReadLine();













