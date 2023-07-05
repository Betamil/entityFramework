namespace ReactWebApp.Entity.Models;

public class Order
{
    public int Id { get; set; }
    public Customer Costumer { get; set; }
    public Employee Employee { get; set; }
    public DateTime Date { get; set; }
    public DateTime RequiredDate { get; set; }
    public DateTime ShippedDate { get; set; }
    public int ShipVia { get; set; }
    public decimal Freight { get; set; }
    public string  ShipName { get; set; }
    public string  ShipAdress { get; set; }
    public string  ShipCity { get; set; }
    public string  ShipRegion { get; set; }
    public string  ShipPostalCode { get; set; }
    public string  ShipCountry { get; set; }
}