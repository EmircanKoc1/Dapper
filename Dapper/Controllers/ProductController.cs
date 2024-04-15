using DapperAPI.DTOs;
using DapperAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace DapperAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();

            return Ok(products);

        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            return Ok(product);

        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDTO product)
        {
            _productRepository.CreateProduct(product);

            return Ok();

        }


    }
}
