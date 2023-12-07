
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
        public async Task<IActionResult> GetAllAsync()
        {
            var unitOfMeasures = await _unitOfMeasureService.GetAllAsync();

            return Ok(unitOfMeasures);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var unitOfMeasure = await _unitOfMeasureService.GetAsync(id);

            if (unitOfMeasure != null)
            {
                return Ok(unitOfMeasure);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(UnitOfMeasureDto unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                var addedUnitOfMeasure =await  _unitOfMeasureService.AddAsync(unitOfMeasure);

                return Ok(addedUnitOfMeasure);
            }

            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UnitOfMeasureDto unitOfMeasure)
        {
            if (id != unitOfMeasure.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedUnit =await _unitOfMeasureService.UpdateAsync(unitOfMeasure);

                return Ok(updatedUnit);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedUnit = await _unitOfMeasureService.DeleteAsync(id);

            if (deletedUnit != null)
            {
                return Ok(deletedUnit);
            }

            return NotFound();
        }
    }
}
