using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.Repositories.Definitions
{
    public interface IUnitOfMeasureRepository
    {
        List<UnitOfMeasure> GetAllUnits();

        UnitOfMeasure? GetUnit(int id);

        UnitOfMeasure AddUnit(UnitOfMeasure unitOfMeasure);

        UnitOfMeasure UpdateUnit(UnitOfMeasure unitOfMeasure);

        UnitOfMeasure? DeleteUnit(int id);

    }
}
