using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.Repositories.Definitions
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product? GetProduct(int id);

        Product? AddProduct(Product product);

        Product? UpdateProduct(Product product);

        Product? DeleteProduct(int id);
    }
}
