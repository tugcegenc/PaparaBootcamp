using ProductManagement.Api.Models;

namespace ProductManagement.Api.Service;

public interface IProductService
{
    List<Product> GetAll(string? name, string? sortBy);
    Product GetById(int id);
    Product Add(Product product);
    Product Update(int id, Product product);
    void Delete(int id);
}