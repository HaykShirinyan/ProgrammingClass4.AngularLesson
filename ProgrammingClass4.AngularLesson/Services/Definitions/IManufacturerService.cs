using ProgrammingClass4.AngularLesson.DataTransferObjects;

namespace ProgrammingClass4.AngularLesson.Services.Definitions
{
    public interface IManufacturerService
    {
        Task<List<ManufacturerDto>> GetAllAsync();
    }
}
