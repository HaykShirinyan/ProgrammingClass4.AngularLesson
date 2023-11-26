using ProgrammingClass4.AngularLesson.DataTransferObjects;

namespace ProgrammingClass4.AngularLesson.Services.Definitions
{
    public interface IProductService
    {
        List<ProductDto> GetAllProducts();

        ProductDto? GetProduct(int id);

        ProductDto AddProduct(ProductDto product);

        ProductDto UpdateProduct(ProductDto product);

        ProductDto? DeleteProduct(int id);
    }
}
