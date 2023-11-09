using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Repositories.Implementations;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/unitOfMeasures")]
    [ApiController]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;

        public UnitOfMeasuresController(IUnitOfMeasureRepository unitOfMeasureRepository)
        {
            _unitOfMeasureRepository = unitOfMeasureRepository;
        }

        [HttpGet]
        public IActionResult GetAllUnitOfMeasures()
        {
            var unitOfMeasures = _unitOfMeasureRepository.GetAllUnits();

            return Ok(unitOfMeasures);
        }
        [HttpGet("{id}")]
        public IActionResult GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = _unitOfMeasureRepository.GetUnit(id);

            if (unitOfMeasure != null)
            {
                return Ok(unitOfMeasure);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult AddUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                var addedUnitOfMeasure = _unitOfMeasureRepository.AddUnit(unitOfMeasure);

                return Ok(addedUnitOfMeasure);
            }

            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUnitOfMeasure(int id, UnitOfMeasure unitOfMeasure)
        {
            if (id != unitOfMeasure.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedUnit = _unitOfMeasureRepository.UpdateUnit(unitOfMeasure);

                return Ok(updatedUnit);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUnitOfMeasure(int id)
        {
            var deletedUnit = _unitOfMeasureRepository.DeleteUnit(id);

            if (deletedUnit != null)
            {
                return Ok(deletedUnit);
            }

            return NotFound();
        }
    }
}
