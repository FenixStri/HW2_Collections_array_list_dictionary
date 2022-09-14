// Fenix Strickland
// MIS 3033 Task 3

List<Receipts> receiptList;
receiptList = new List<Receipts>();


Console.WriteLine("Do you want to enter a new receipt? (y/n)?");
string userInput = Console.ReadLine().ToLower();

if (userInput == "y")
{
    while (userInput == "y")
    {
        Console.WriteLine("Please input the number of cogs:");
        int cogsAmtInput = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please input the number of gears:");
        int gearsAmtInput = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please input the Customer ID:");
        int custIDInput = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("==============================");
        Receipts newReceipt1 = new Receipts(cogsAmtInput, gearsAmtInput, custIDInput);
        receiptList.Add(newReceipt1);

        Console.WriteLine(newReceipt1);
        Console.WriteLine("==============================");
        Console.WriteLine("Do you want to enter a new receipt? (y/n)");
        userInput = Console.ReadLine().ToLower();

    }
}
else if (userInput == "n")
{
    Console.WriteLine("");
}




do
{
    Console.WriteLine("Please choose from the options:");
    Console.WriteLine("1: Print all receipts of one customer");
    Console.WriteLine("2: Print all receipts for today");
    Console.WriteLine("3: Print the highest total receipt");
    Console.WriteLine("Press other keys to end");
    userInput = Console.ReadLine();

    if (userInput == "1")
    {
        bool ccustid = false;
        Console.WriteLine("Please enter a customer ID: ");
        string userInputccustID = Console.ReadLine();

        for (int i = 0; i < receiptList.Count; i++)
        {
            if (userInputccustID == receiptList[i].custID.ToString())
            {
                ccustid = true;
                Console.WriteLine("==============================");
                Console.WriteLine(receiptList[i]);
            }

        }
        if (ccustid == false)
        {
            Console.WriteLine("");
        }
        Console.WriteLine("==============================");

    }
    else if (userInput == "2")
    {
        bool todaysDate = false;
        for (int i = 0; i < receiptList.Count; i++)
        {
            if (DateTime.Now.ToString("d") == receiptList[i].salesDate.ToString("d"))
            {
                todaysDate = true;
                Console.WriteLine("==============================");
                Console.WriteLine(receiptList[i]);
            }
        }
        if (todaysDate == false)
        {
            Console.WriteLine("");

        }
        Console.WriteLine("==============================");

    }
    else if (userInput == "3")
    {
        Receipts highReceipt = receiptList[0];

        for (int i = 0; i < receiptList.Count; i++)
        {
            if (highReceipt.calcTotal() < receiptList[i].calcTotal())
            {
                highReceipt = receiptList[i];
            }
        }

        Console.WriteLine($"The highest total is {highReceipt.calcTotal().ToString("C2")}");
        for (int i = 0; i < receiptList.Count; i++)
        {
            Console.WriteLine(receiptList[i]);
        }
        Console.WriteLine("==============================");
    }
    else
    {
        Console.WriteLine("Goodbye");
        break;
    }
   
} while (userInput == "1" || userInput == "2" || userInput == "3" );


public class Receipts
{
    const double cogprice = 79.99;
    const double gearprice = 250.00;
    const double markup = .15;
    const double discountMarkup = .125;
    const double salestax = 0.089;
    public int cogamt;
    public int gearamt;
    public int custID;
    public DateTime salesDate;

    public override string ToString()
    {
        string mstring = "";
        mstring = mstring + "RECEIPT\n" + string.Format("Customer ID: {0}\n", this.custID) + string.Format("# of Cogs: {0}\n", this.cogamt);
        mstring = mstring + string.Format("# of Gears: {0}\n", this.gearamt) + string.Format("Net amount: {0:C2}\n", this.calcNetAmt());
        mstring += string.Format("Sales tax: {0:C2}\n", this.calcTax());
        mstring += string.Format("Grand total: {0:C2}\n", this.calcTotal());
        mstring += string.Format("Time {0}\n", this.salesDate);
        return mstring;

    }
    public Receipts()
    {
        salesDate = DateTime.Now;
        this.cogamt = 0;
        this.gearamt = 0;
        this.custID = -1;
    }
    public Receipts(int numcogs, int numgears, int custid)
    {
        salesDate = DateTime.Now;
        this.cogamt = numcogs;
        this.gearamt = numgears;
        this.custID = custid;
    }
    public double calcNetAmt()
    {
        double netAmt = 0;
        double realMarkup;
        netAmt = this.cogamt * cogprice + this.gearamt * gearprice;

        if(this.gearamt + this.cogamt > 16 || this.gearamt > 10 || this.cogamt > 10)
        {
            realMarkup = 0.125;
        }
        else
        {
            realMarkup = 0.15;
        }

        netAmt = netAmt * (1 + realMarkup);
        return netAmt;
    }

    public double calcTax()
    {
       double calculatedTax = this.calcNetAmt() * Receipts.salestax;

        return calculatedTax;
    }

    public double calcTotal()
    {
        double calculatedtotal = 0;

        calculatedtotal = this.calcNetAmt() + this.calcTax();
        return calculatedtotal;
    }

    public void PrintReceipt()
    {
        Console.WriteLine("RECEIPT");
        Console.WriteLine($"Customer ID: {this.custID}");
        Console.WriteLine($"# of Cogs: {this.cogamt}");
        Console.WriteLine($"# of Gears: {this.gearamt}");
        Console.WriteLine($"Net amount: {this.calcNetAmt()}");
        Console.WriteLine($"Sales tax: {this.calcTax()}");
        Console.WriteLine($"Grand total: {this.calcTotal()}");
        Console.WriteLine($"Time: {this.salesDate}");
        Console.WriteLine(this.salesDate.ToString());

    }


}
//public override string ToString()
//{
//    string stringMsg = "";
//    stringMsg = stringMsg
//}

