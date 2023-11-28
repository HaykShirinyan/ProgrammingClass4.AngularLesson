using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.DataTransferObjects;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Repositories.Implementations;
using ProgrammingClass4.AngularLesson.Services.Definitions;
using System.Reflection.Metadata.Ecma335;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/producttypes")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }
        [HttpGet]
        public IActionResult GetAllProductTypes()
        {
            var productTypes = _productTypeService.GetAllProductTypes();

            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductType(int id)
        {
            var productType = _productTypeService.GetProductType(id);

            if (productType != null)
            {
                return Ok(productType);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProductType(ProductTypeDto productType)
        {
            if (ModelState.IsValid)
            {
                var addedProductType = _productTypeService.AddProductType(productType);
                    
                return Ok(addedProductType);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductType(int id, ProductTypeDto productType)
        {
            if (productType.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var updatedProductType = _productTypeService.UpdateProductType(productType);

                return Ok(productType);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductType(int id)
        {
            var deletedPorductType = _productTypeService.DeleteProductType(id);

            if (deletedPorductType != null)
            {
                return Ok(deletedPorductType);
            }

            return NotFound();
        }
    }
}
