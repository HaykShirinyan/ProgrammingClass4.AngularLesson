
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
    [Route("api/unitOfMeasures")]
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
                var addedUnitOfMeasure = _unitOfMeasureService.AddUnitOfMeasure(unitOfMeasure);

                return Ok(addedUnitOfMeasure);
            }

            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUnitOfMeasure(int id, UnitOfMeasureDto unitOfMeasure)
        {
            if (id != unitOfMeasure.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedUnit = _unitOfMeasureService.UpdateUnitOfMeasure(unitOfMeasure);

                return Ok(updatedUnit);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUnitOfMeasure(int id)
        {
            var deletedUnit = _unitOfMeasureService.DeleteUnitOfMeasure(id);

            if (deletedUnit != null)
            {
                return Ok(deletedUnit);
            }

            return NotFound();
        }
    }
}
