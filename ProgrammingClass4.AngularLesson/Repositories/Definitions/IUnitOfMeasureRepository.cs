using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.Repositories.Definitions
{
    public interface IUnitOfMeasureRepository
    {
        Task<List<UnitOfMeasure>> GetAllAsync();

        Task<UnitOfMeasure?> GetAsync(int id);

        Task<UnitOfMeasure> AddAsync(UnitOfMeasure unitOfMeasure);

        Task<UnitOfMeasure> UpdateAsync(UnitOfMeasure unitOfMeasure);

        Task<UnitOfMeasure?> DeleteAsync(int id);

    }
}
