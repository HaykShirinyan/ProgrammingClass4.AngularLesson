using ProgrammingClass4.AngularLesson.DataTransferObjects;

namespace ProgrammingClass4.AngularLesson.Services.Definitions
{
    public interface IUnitOfMeasureService
    {
        List<UnitOfMeasureDto> GetAllUnitOfMeasures();

        UnitOfMeasureDto? GetUnitOfMeasure(int id);

        UnitOfMeasureDto AddUnitOfMeasure(UnitOfMeasureDto unitOfMeasur);

        UnitOfMeasureDto UpdateUnitOfMeasure(UnitOfMeasureDto unitOfMeasure);

        UnitOfMeasureDto? DeleteUnitOfMeasure(int id);
    }
}
