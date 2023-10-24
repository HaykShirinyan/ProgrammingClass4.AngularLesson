using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.Controllers
{
    [Route("api/unitOfMeasure")]
    [ApiController]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfMeasuresController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUnitOfMeasures()
        {
            var unitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return Ok(unitOfMeasures);
        }
        [HttpGet("{id}")]
        public IActionResult GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = _dbContext.UnitOfMeasures.Find(id);

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
                _dbContext.UnitOfMeasures.Add(unitOfMeasure);
                _dbContext.SaveChanges();

                return Ok(unitOfMeasure);
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
                _dbContext.UnitOfMeasures.Update(unitOfMeasure);
                _dbContext.SaveChanges();

                return Ok(unitOfMeasure);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUnitOfMeasure(int id)
        {
            var unitOfMeasure = _dbContext.UnitOfMeasures.Find(id);

            if (unitOfMeasure != null)
            {
                _dbContext.UnitOfMeasures.Remove(unitOfMeasure);
                _dbContext.SaveChanges();

                return Ok(unitOfMeasure);
            }

            return NotFound();
        }
    }
}
