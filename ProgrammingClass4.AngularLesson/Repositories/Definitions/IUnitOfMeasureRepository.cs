using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.Repositories.Definitions
{
    public interface IUnitOfMeasureRepository
    {
        List<UnitOfMeasure> GetAllUnitOfMeasures();

        UnitOfMeasure? GetUnitOfMeasure(int id);

        UnitOfMeasure? AddUnitOfMeasure(UnitOfMeasure unitOfMeasure);

        UnitOfMeasure? UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure);

        UnitOfMeasure? DeleteUnitOfMeasure(int id);
    }
}
