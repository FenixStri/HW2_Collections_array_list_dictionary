// Fenix Strickland
// MIS 3033 Task 1

string[] itemNameArr;
itemNameArr = new string[5] { "apples", "oranges", "bananas", "grapes", "blueberries" };

double[] itemPriceArr;
itemPriceArr = new double[5] {0.99, 0.50, 0.50, 2.99, 1.99};

Console.WriteLine("Items List:");
foreach (string str in itemNameArr)
{
    Console.WriteLine(str);
}

Console.WriteLine("Please input the item name you want to show the price:");
string userInp = Console.ReadLine();

Boolean list = false;
for (int i = 0; i < 5; i++)
{
    if (userInp == itemNameArr[i])
    {
        list = true;
        Console.WriteLine($"The price for {userInp} is {itemPriceArr[i]:c2}");
    }
    
}
if (list == false)
{
    Console.WriteLine("Item name Input Error!");
}

Console.ReadLine();
