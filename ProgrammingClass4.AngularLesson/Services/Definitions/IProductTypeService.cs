using ProgrammingClass4.AngularLesson.DataTransferObjects;

namespace ProgrammingClass4.AngularLesson.Services.Definitions
{
    public interface IProductTypeService
    {
        List<ProductTypeDto> GetAllProductTypes();

        ProductTypeDto? GetProductType(int id);

        ProductTypeDto AddProductType(ProductTypeDto productType);

        ProductTypeDto UpdateProductType(ProductTypeDto productType);

        ProductTypeDto? DeleteProductType(int id);
    }
}
