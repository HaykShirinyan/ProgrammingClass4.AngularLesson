using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;

namespace ProgrammingClass4.AngularLesson.Repositories.Implementations
{
    public class UnitOfMeasureRepository :IUnitOfMeasureRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public UnitOfMeasureRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<UnitOfMeasure> GetAllUnits()
        {
            return _dbContext.UnitOfMeasures.ToList();
        }

        public UnitOfMeasure? GetUnit(int id)
        {
            return _dbContext.UnitOfMeasures.Find(id);
        }

        public UnitOfMeasure AddUnit(UnitOfMeasure unitOfMeasure)
        {
            _dbContext.UnitOfMeasures.Add(unitOfMeasure);
            _dbContext.SaveChanges();

            return unitOfMeasure;
        }

        public UnitOfMeasure UpdateUnit(UnitOfMeasure unitOfMeasure)
        {
            _dbContext.UnitOfMeasures.Update(unitOfMeasure);
            _dbContext.SaveChanges();

            return unitOfMeasure;
        }

        public UnitOfMeasure? DeleteUnit(int id)
        {
            var unitOfMeasure = _dbContext.UnitOfMeasures.Find(id);

            if (unitOfMeasure != null)
            {
                _dbContext.UnitOfMeasures.Remove(unitOfMeasure);
                _dbContext.SaveChanges();

                return unitOfMeasure;
            }

            return null;
        }
    }
}
