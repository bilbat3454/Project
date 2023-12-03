public class Clothing : Order
{
    public int ClothingID { get; set; }
    public string ClothingName { get; set; }
    public int Qty { get; set; }
    public int Cost { get; set; }
    public bool BackorderStatus { get; set; }
    
    public Clothing(int orderNum, string orderDate, bool shippingStatus, 
        int clothingID, string clothingName, int qty, int cost, 
        bool backorderStatus) : base(orderNum, orderDate, shippingStatus)
    {
        ClothingID = clothingID;
        ClothingName = clothingName;
        Qty = qty;
        Cost = cost;
        BackorderStatus = backorderStatus;
    }
    
    public override string ToString()
    {
        return string.Format(
            "{0}\nClothing ID: {1}\nClothing Name: {2}\nQuantity: {3}\nCost: ${4}\nBackorder Status: {5}\n",
            GetOrderInfo(), ClothingID, ClothingName, Qty, Cost, BackorderStatus ? "Backordered" : "Not Backordered");
    }
}