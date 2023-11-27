using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.DataTransferObjects;
using ProgrammingClass4.AngularLesson.Services.Definitions;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var addedProduct = _productService.AddProduct(product);
                return Ok(addedProduct);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductDto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedProduct = _productService.UpdateProduct(product);

                return Ok(updatedProduct);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deletedProduct = _productService.DeleteProduct(id);

            if (deletedProduct != null)
            {
                return Ok(deletedProduct);
            }

            return NotFound();
        }
    }
}
