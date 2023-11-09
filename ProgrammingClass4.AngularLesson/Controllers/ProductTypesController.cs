using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Repositories.Implementations;
using System.Reflection.Metadata.Ecma335;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/producttypes")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypesController(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        [HttpGet]
        public IActionResult GetAllProductTypes()
        {
            var productTypes = _productTypeRepository.GetAllProductTypes();

            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductType(int id)
        {
            var productType = _productTypeRepository.GetProductType(id);

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
                var addedProductType = _productTypeRepository.AddProductType(productType);
                    
                return Ok(addedProductType);
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
                var updatedProductType = _productTypeRepository.UpdateProductType(productType);

                return Ok(productType);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductType(int id)
        {
            var deletedPorductType = _productTypeRepository.DeleteProductType(id);

            if (deletedPorductType != null)
            {
                return Ok(deletedPorductType);
            }

            return NotFound();
        }
    }
}
