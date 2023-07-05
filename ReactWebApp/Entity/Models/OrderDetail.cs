namespace ReactWebApp.Entity.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public char UnitPrice { get; set; }
    public short Quantity { get; set; }
    public int Discount { get; set; }
}