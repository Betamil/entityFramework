using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactWebApp.Entity.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(40)")]
    public string? ProductName { get; set; }
    public Supplier? Supplier { get; set; }
    public Category? Category { get; set; }
    [Column(TypeName = "nvarchar(20)")]
    public string? QuantityPerUnit { get; set; }
    [DefaultValue(0)]
    [Column(TypeName = "money")]
    public int? UnitPrice { get; set; }
    [DefaultValue(0)]
    [Column(TypeName = "smalint")]
    public int? UnitsInStock { get; set; }
    [DefaultValue(0)]
    [Column(TypeName = "smalint")]
    public int? UnitsOnOrder { get; set; }
    [Required]
    [DefaultValue(0)]
    [Column(TypeName = "bit")]
    public int RecorderLevel { get; set; }
}

