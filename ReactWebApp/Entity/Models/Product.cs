using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactWebApp.Entity.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = string.Empty;
    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }
    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }
    [DefaultValue(0)]
    [Column(TypeName = "money")]
    public int? UnitPrice { get; set; }
    [DefaultValue(0)]
    [Column(TypeName = "smalint")]
    [Range(-32768, 32767)]
    public int? UnitsInStock { get; set; }
    [DefaultValue(0)]
    [Column(TypeName = "smalint")]
    [Range(-32768, 32767)]
    public int? UnitsOnOrder { get; set; }
    [Required]
    [DefaultValue(0)]
    [Column(TypeName = "bit")]
    public int RecorderLevel { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }
    [ForeignKey("SupplierId")]
    public virtual Supplier? Supplier { get; set; }
}

