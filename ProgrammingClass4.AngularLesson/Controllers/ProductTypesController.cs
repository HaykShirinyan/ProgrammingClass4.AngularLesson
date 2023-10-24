using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/productTypes")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductTypesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllProductTypes()
        {
            var productTypes = _dbContext.ProductTypes.ToList();

            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductType(int id)
        {
            var productType = _dbContext.ProductTypes.Find(id);

            if (productType != null)
            {
                return Ok(productType);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProductType(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductTypes.Add(productType);
                _dbContext.SaveChanges();

                return Ok(productType);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductType(int id, ProductType productType)
        {
            if (productType.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _dbContext.ProductTypes.Update(productType);
                _dbContext.SaveChanges();

                return Ok(productType);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductType(int id)
        {
            var productType = _dbContext.ProductTypes.Find(id);

            if (productType != null)
            {
                _dbContext.ProductTypes.Remove(productType);
                _dbContext.SaveChanges();

                return Ok(productType);
            }

            return NotFound();
        }
    }
}
