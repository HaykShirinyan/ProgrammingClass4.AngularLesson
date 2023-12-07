using ProgrammingClass4.AngularLesson.DataTransferObjects;

namespace ProgrammingClass4.AngularLesson.Services.Definitions
{
    public interface IProductTypeService
    {
        Task<List<ProductTypeDto>> GetAllAsync();

        Task<ProductTypeDto?> GetAsync(int id);

        Task<ProductTypeDto> AddAsync(ProductTypeDto productType);

        Task<ProductTypeDto> UpdateAsync(ProductTypeDto productType);

        Task<ProductTypeDto?> DeleteAsync(int id);
    }
}
