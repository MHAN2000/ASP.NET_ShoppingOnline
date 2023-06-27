using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Data.Repositories;
using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Data.Services
{
    public class ProductService : IProductRepository
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Product> AddProduct(ProductDTO request)
        {
            var product = _mapper.Map<Product>(request);
            _context.Products.Add(product);
            // Save changes
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<Product?> DeleteProduct(int id)
        {
            // Try to find the product
            var product = await _context.Products.FindAsync(id);
            // If Product was not found return null, else delete it
            if (product == null) return null;
            _context.Products.Remove(product);
            // Save changes
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            // Find the Product by its id
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;
            return product;
        }

        public async Task<Product?> UpdateProduct([FromBody] ProductDTO request, int id)
        {
            // Try to find the Product
            var product = await _context.Products.FindAsync(id);
            // If no product was found return null, else update it
            if (product == null) return null;
            product.ProductName = request.ProductName;
            product.Description = request.Description;
            product.UnitPrice = request.UnitPrice;
            product.Quantity = request.Quantity;
            await _context.SaveChangesAsync();
            return product;


        }
    }
}
