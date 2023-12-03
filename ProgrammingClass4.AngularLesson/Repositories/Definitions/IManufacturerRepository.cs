using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.Repositories.Definitions
{
    public interface IManufacturerRepository
    {
        Task<List<Manufacturer>> GetAllAsync();

        Task<Manufacturer> GetAsync(int id);

        Task<Manufacturer> AddAsync(Manufacturer manufacturer);

        Task<Manufacturer> UpdateAsync(Manufacturer manufacturer);
    }
}
