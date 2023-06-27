using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Data.Repositories;
using ShoppingOnline.Models;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(ProductDTO request)
        {
            var product = await _productRepository.AddProduct(request);
            if (product == null) return StatusCode(500, "An internal server error has ocurred");
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct()
        {
            return Ok(await _productRepository.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound("The product has not been found");
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct([FromBody] ProductDTO request, int id)
        {
            var product = await _productRepository.UpdateProduct(request, id);
            if (product == null) return NotFound("The product has not been found");
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> DeleteProduct(int id)
        {
            var product = await _productRepository.DeleteProduct(id);
            if (product == null) return NotFound("The product has not been found");
            return Ok(_mapper.Map<ProductDTO>(product));
        }
    }
}
