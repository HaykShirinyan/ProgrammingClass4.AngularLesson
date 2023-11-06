using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Implementations;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/unit-of-measures")]
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
            var unitOfMeasures = _unitOfMeasureRepository.GetAllUnitOfMeasures();
            return Ok(unitOfMeasures);
        }

        [HttpGet("{id}")]
        public IActionResult GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = _unitOfMeasureRepository.GetUnitOfMeasure(id);

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
                var addUnitOfMeasure = _unitOfMeasureRepository.AddUnitOfMeasure(unitOfMeasure);
                return Ok(addUnitOfMeasure);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUnitOfMeasure(int id,  UnitOfMeasure unitOfMeasure)
        {
            if(id !=unitOfMeasure.Id)
            {
                return BadRequest();
            }

            if(ModelState.IsValid)
            {
                var updateUnitOfMeasure = _unitOfMeasureRepository.UpdateUnitOfMeasure(unitOfMeasure);
                return Ok(updateUnitOfMeasure);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUnitOfMeasure(int id)
        {
            var deleteUnitOfMeasure = _unitOfMeasureRepository.DeleteUnitOfMeasure(id);

            if(deleteUnitOfMeasure != null)
            {
                return Ok(deleteUnitOfMeasure);
            }

            return NotFound();
        }
    }
}
