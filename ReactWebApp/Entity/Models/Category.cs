using System.ComponentModel.DataAnnotations;

namespace ReactWebApp.Entity.Models;

public class Category
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required] [StringLength(15)] 
    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string Picture { get; set; } = string.Empty;
}