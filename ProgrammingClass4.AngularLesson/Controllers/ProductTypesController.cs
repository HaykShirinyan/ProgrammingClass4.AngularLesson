using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.DataTransferObjects;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Repositories.Implementations;
using ProgrammingClass4.AngularLesson.Services.Definitions;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/product-types")]
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
            
            var productType =_productTypeService.GetProductType(id);
            
            if(productType !=null) 
            { 
                return Ok(productType);
            
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProductType(ProductTypeDto productType)
        {
            if(ModelState.IsValid)
            {
                var addProductType = _productTypeService.AddProductType(productType);
                return Ok(addProductType);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductType( int id, ProductTypeDto productType) 
        {
            if (id != productType.Id)
            {
                return BadRequest();
            }
           
            if(ModelState.IsValid)
            {
               var updateProductType = _productTypeService.UpdateProductType(productType);
                return Ok(updateProductType);
               
            }
            
            return BadRequest(ModelState);
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductType(int id)
        {
            var deleteProductType = _productTypeService.DeleteProductType(id);

            if (deleteProductType != null)
            {
                return Ok(deleteProductType);
            }
            return NotFound();
        }
    }
}
