using System.ComponentModel.DataAnnotations;

namespace ReactWebApp.Entity.Models;

public class Shipper
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; }
    [StringLength(24)]
    public string Phone { get; set; }
}