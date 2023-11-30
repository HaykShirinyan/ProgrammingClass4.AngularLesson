using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Implementations;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Services.Definitions;
using ProgrammingClass4.AngularLesson.DataTransferObjects;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/unit-of-measures")]
    [ApiController]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly IUnitOfMeasureService _unitOfMeasureService;

        public UnitOfMeasuresController(IUnitOfMeasureService unitOfMeasureService)
        {
            _unitOfMeasureService = unitOfMeasureService;
        }

        [HttpGet]
        public IActionResult GetAllUnitOfMeasures()
        {
            var unitOfMeasures = _unitOfMeasureService.GetAllUnitOfMeasures();
            return Ok(unitOfMeasures);
        }

        [HttpGet("{id}")]
        public IActionResult GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = _unitOfMeasureService.GetUnitOfMeasure(id);

            if (unitOfMeasure != null)
            {
                return Ok(unitOfMeasure);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddUnitOfMeasure(UnitOfMeasureDto unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                var addUnitOfMeasure = _unitOfMeasureService.AddUnitOfMeasure(unitOfMeasure);
                return Ok(addUnitOfMeasure);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUnitOfMeasure(int id,  UnitOfMeasureDto unitOfMeasure)
        {
            if(id !=unitOfMeasure.Id)
            {
                return BadRequest();
            }

            if(ModelState.IsValid)
            {
                var updateUnitOfMeasure = _unitOfMeasureService.UpdateUnitOfMeasure(unitOfMeasure);
                return Ok(updateUnitOfMeasure);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUnitOfMeasure(int id)
        {
            var deleteUnitOfMeasure = _unitOfMeasureService.DeleteUnitOfMeasure(id);

            if(deleteUnitOfMeasure != null)
            {
                return Ok(deleteUnitOfMeasure);
            }

            return NotFound();
        }
    }
}
