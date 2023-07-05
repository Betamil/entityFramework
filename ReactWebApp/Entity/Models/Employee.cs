using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactWebApp.Entity.Models;

public class Employee
{
    [Key]
    [Required]
    [Column(Order = 1)]
    public int Id { get; set; }
    [Required]
    [Column(Order = 3)]
    public string FirstName { get; set; } = String.Empty;
    [Required]
    [StringLength(20)]
    [Column(Order = 2)]
    public string LastName { get; set; } = String.Empty;
    [StringLength(30)]
    public string Title { get; set; } = String.Empty;
    [StringLength(25)]
    public string TitleOfCourtesy { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    [StringLength(60)]
    public string Address { get; set; } = string.Empty;
    [StringLength(15)]
    public string City { get; set; } = string.Empty;
    [StringLength(15)]
    public string Region { get; set; } = string.Empty;
    [StringLength(10)]
    public string PostaleCode { get; set; } = string.Empty;
    [StringLength(15)]
    public string Country { get; set; } = string.Empty;
    [StringLength(24)]
    public string HomePhone { get; set; } = string.Empty;
    [StringLength(4)]
    public string Extension { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    [ForeignKey("Id")]
    public int ReportsTo { get; set; }
    [StringLength(255)]
    public string PhotoPath { get; set; } = string.Empty;
}