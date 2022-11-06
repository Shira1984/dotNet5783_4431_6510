

using System.Xml.Linq;

namespace DO;

public struct OrderItem
{
    public int ProductID { get; set; }
    public string OrderID { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }


    public override string ToString() => $@"
ProductID = {ProductID},
OrderID = {OrderID},
Price = {Price},
Amount = {Amount}
";
}
