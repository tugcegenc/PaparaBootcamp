using FluentValidation;
using ProductManagement.Api.Models;
using ProductManagement.Api.Validators;

namespace ProductManagement.Api.Service;

public class FakeProductService : IProductService
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "Gaming Laptop", Stock = 10, IsAvailable = true },
        new Product { Id = 2, Name = "Mouse", Price = 50, Description = "Wireless Mouse", Stock = 50, IsAvailable = true },
        new Product { Id = 3, Name = "Keyboard", Price = 50, Description = "Keyboard", Stock = 30, IsAvailable = true },
        new Product { Id = 4, Name = "Monitor", Price = 300, Description = "4K Monitor", Stock = 50, IsAvailable = true }
    };

    private static int _nextId = 5;

    public List<Product> GetAll(string? name, string? sortBy)
    {
        var products = _products.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            products = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            products = sortBy.ToLower() switch
            {
                "price" => products.OrderBy(p => p.Price),
                "name" => products.OrderBy(p => p.Name),
                _ => products
            };
        }

        return products.ToList();
    }

    public Product GetById(int id)
    {
        var product = _products.SingleOrDefault(x => x.Id == id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }
        return product;
    }

    public Product Add(Product product)
    {
        var validator = new ProductValidator();
        var validationResult = validator.Validate(product);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        if (_products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new Exception("A product with the same name already exists.");
        }

        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }

    public Product Update(int id, Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct == null)
            throw new KeyNotFoundException("Product not found.");

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Description = product.Description;
        existingProduct.Stock = product.Stock;
        existingProduct.IsAvailable = product.IsAvailable;

        return existingProduct;
    }

    public void Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            throw new KeyNotFoundException("Product not found.");

        _products.Remove(product);
    }
}
