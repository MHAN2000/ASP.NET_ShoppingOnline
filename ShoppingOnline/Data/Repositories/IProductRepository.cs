using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(ProductDTO product);
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product?> DeleteProduct(int id);
        Task<Product?> UpdateProduct(ProductDTO request, int id);
    }
}
