using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Api.Models;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
  
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public int Stock { get; set; }

    public bool IsAvailable { get; set; }
}