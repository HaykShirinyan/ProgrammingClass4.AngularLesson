using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.Repositories.Definitions
{
    public interface IProductTypeRepository
    {
        List<ProductType> GetAllProductTypes();

        ProductType? GetProductType(int id);

        ProductType? AddProductType(ProductType productType);

        ProductType? UpdateProductType(ProductType productType);
        
        ProductType? DeleteProductType(int id);
    }
}
