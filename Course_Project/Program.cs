class Program 
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nBilal Bates - Course Project - ThriftX");
        Order o = new Order(17, "11/10/23", false);
        Clothing cc = new Clothing(300, "6/8/23", true, 452, "White T-Shirt", 3, 40, false);
        Membership m = new Membership(2, "9/10/23", true, "John Smith", "432 Bleeker Dr", 999, true);

        Order o2 = new Order(18, "10/31/23", true);
        Clothing cc2 = new Clothing(410, "7/10/23", false, 600, "Black Denim Jeans", 2, 50, false);
        Membership m2 = new Membership(2, "9/10/23", true, "Bilal Bates", "123 Southwest Ave", 350, false);

        Console.WriteLine("\nOrder 1");
        
        Console.WriteLine("\nOrder Information:\n   Order Number: {0}\n   Order Date: {1}\n   Shipping Status: {2}" + 
            "\nCustomer Information:\n   Customer Name: {3}\n   Customer Address: {4}\n   Customer ID: {5}" +
            "\n   Do they have a membership? {6}\nClothing Purchased:\n   Clothing ID: {7}\n   Clothing Name: {8}" +
            "\n   Quantity: {9}\n   Cost: ${10}\n   Backorder Status: {11}", 
            o.OrderNum, o.OrderDate, o.ShippingStatus ? "Shipped" : "Not Shipped", m.Name, m.Address, m.CustomerID, m.MemberStatus ? "Yes" : "No", cc.ClothingID,
            cc.ClothingName, cc.Qty, cc.Cost, cc.BackorderStatus ? "Backordered" : "Not Backordered");

        Console.WriteLine("\nOrder 2");

        Console.WriteLine("\nOrder Information:\n   Order Number: {0}\n   Order Date: {1}\n   Shipping Status: {2}" + 
            "\nCustomer Information:\n   Customer Name: {3}\n   Customer Address: {4}\n   Customer ID: {5}" +
            "\n   Do they have a membership? {6}\nClothing Purchased:\n   Clothing ID: {7}\n   Clothing Name: {8}" +
            "\n   Quantity: {9}\n   Cost: ${10}\n   Backorder Status: {11}", 
            o2.OrderNum, o2.OrderDate, o2.ShippingStatus ? "Shipped" : "Not Shipped", m2.Name, m2.Address, m2.CustomerID, m2.MemberStatus ? "Yes" : "No", cc2.ClothingID,
            cc2.ClothingName, cc2.Qty, cc2.Cost, cc2.BackorderStatus ? "Backordered" : "Not Backordered");
    }
}