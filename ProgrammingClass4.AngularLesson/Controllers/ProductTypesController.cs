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
        public async Task<IActionResult> GetAllAsync()
        {
            var productTypes = await _productTypeService.GetAllAsync();

            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var productType = await _productTypeService.GetAsync(id);

            if (productType != null)
            {
                return Ok(productType);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductTypeDto productType)
        {
            if (ModelState.IsValid)
            {
                var addedProductType = await _productTypeService.AddAsync(productType);
                    
                return Ok(addedProductType);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProductTypeDto productType)
        {
            if (productType.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var updatedProductType = await _productTypeService.UpdateAsync(productType);

                return Ok(productType);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedPorductType = await _productTypeService.DeleteAsync(id);

            if (deletedPorductType != null)
            {
                return Ok(deletedPorductType);
            }

            return NotFound();
        }
    }
}
