using ProgrammingClass4.AngularLesson.DataTransferObjects;

namespace ProgrammingClass4.AngularLesson.Services.Definitions
{
    public interface IUnitOfMeasureService
    {
        Task<List<UnitOfMeasureDto>> GetAllAsync();

        Task<UnitOfMeasureDto?> GetAsync(int id);

        Task<UnitOfMeasureDto> AddAsync(UnitOfMeasureDto unitOfMeasure);

        Task<UnitOfMeasureDto> UpdateAsync(UnitOfMeasureDto unitOfMeasure);

        Task<UnitOfMeasureDto>? DeleteAsync(int id);
    }
}
