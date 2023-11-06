using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;

namespace ProgrammingClass4.AngularLesson.Repositories.Implementations
{
    public class UnitOfMeasureRepository:IUnitOfMeasureRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfMeasureRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UnitOfMeasure> GetAllUnitOfMeasures()
        {
            return _dbContext.UnitOfMeasures.ToList();
        }

        public UnitOfMeasure? GetUnitOfMeasure(int id)
        {
            return _dbContext.UnitOfMeasures.SingleOrDefault(s => s.Id == id);
        }

        public UnitOfMeasure AddUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            _dbContext.UnitOfMeasures.Add(unitOfMeasure);
            _dbContext.SaveChanges();
            return unitOfMeasure;
        }

        public UnitOfMeasure UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            _dbContext.UnitOfMeasures.Update(unitOfMeasure);
            _dbContext.SaveChanges();
            return unitOfMeasure;
        }

        public UnitOfMeasure? DeleteUnitOfMeasure(int id)
        {
            var unitOfMeasure = _dbContext.UnitOfMeasures.SingleOrDefault(p=>p.Id==id);

            if(unitOfMeasure != null)
            {
                _dbContext.Remove(unitOfMeasure);
                _dbContext.SaveChanges();
                return unitOfMeasure;
            }

            return null;
        }
    }
}
