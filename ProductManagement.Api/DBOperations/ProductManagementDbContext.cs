using Microsoft.EntityFrameworkCore;
using ProductManagement.Api.Models;

namespace ProductManagement.Api.DBOperations;

public class ProductManagementDbContext : DbContext
{
    public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
}

