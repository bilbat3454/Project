public class Membership : Customer
{
    public bool MemberStatus { get; set; }

    
    public Membership(int orderNum, string orderDate, bool shippingStatus, 
        string name, string address, int customerID, bool memberStatus) 
        : base(orderNum, orderDate, shippingStatus, name, address, customerID)
    {
        MemberStatus = memberStatus;
    }

    public override string GetOrderInfo()
    {
        return string.Format("{0}\nDo they have a membership? {1}",
            base.GetOrderInfo(), MemberStatus ? "Yes" : "No");
    }
   
    public override string ToString()
    {
        return string.Format("{0}\nDo they have a membership? {1}",
            base.GetOrderInfo(), MemberStatus ? "Yes" : "No"); 
    }
}
