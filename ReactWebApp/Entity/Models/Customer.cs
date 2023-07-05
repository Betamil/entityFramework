using System.ComponentModel.DataAnnotations;

namespace ReactWebApp.Entity.Models;

public class Customer
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required] 
    [StringLength(40)]
    public string CompanyName { get; set; } = string.Empty;
    [StringLength(30)]
    public string ContactName { get; set; } = string.Empty;
    [StringLength(30)]
    public string ContactTitle { get; set; } = string.Empty;
    [StringLength(60)]
    public string Adress { get; set; } = string.Empty;
    [StringLength(15)]
    public string City { get; set; } = string.Empty;
    [StringLength(15)]
    public string Region { get; set; } = string.Empty;
    [StringLength(10)]
    public string PostalCode { get; set; } = string.Empty;
    [StringLength(15)]
    public string Country { get; set; } = string.Empty;
    [StringLength(24)]
    public string Phone { get; set; } = string.Empty;
    [StringLength(24)]
    public string Fax { get; set; } = string.Empty;
}