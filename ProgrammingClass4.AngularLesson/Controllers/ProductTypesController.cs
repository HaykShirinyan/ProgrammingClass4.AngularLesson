using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Repositories.Implementations;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/product-types")]
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
            
            if(productType !=null) 
            { 
                return Ok(productType);
            
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProductType(ProductType productType)
        {
            if(ModelState.IsValid)
            {
                var addProductType = _productTypeRepository.AddProductType(productType);
                return Ok(addProductType);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductType( int id, ProductType productType) 
        {
            if (id != productType.Id)
            {
                return BadRequest();
            }
           
            if(ModelState.IsValid)
            {
               var updateProductType = _productTypeRepository.UpdateProductType(productType);
                return Ok(updateProductType);
               
            }
            
            return BadRequest(ModelState);
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductType(int id)
        {
            var deleteProductType = _productTypeRepository.DeleteProductType(id);

            if (deleteProductType != null)
            {
                return Ok(deleteProductType);
            }
            return NotFound();
        }
    }
}
