public class Customer : Order
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int CustomerID { get; set; }

    public Customer(int orderNum, string orderDate, bool shippingStatus, 
        string name, string address, int customerID) 
        : base(orderNum, orderDate, shippingStatus)
    {
        Name = name;
        Address = address;
        CustomerID = customerID;
    }

    public override string GetOrderInfo()
    {
        return string.Format("{0}\nCustomer Name: {1}\nCustomer Address: {2}\nCustomer ID: {3}",
            base.GetOrderInfo(), Name, Address, CustomerID);
    }

    public override string ToString()
    {
        return string.Format("{0}\nCustomer Name: {1}\nCustomer Address: {2}\nCustomer ID: {3}",
            base.GetOrderInfo(), Name, Address, CustomerID);
    }
}
