using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;

namespace ProgrammingClass4.AngularLesson.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext
                .Products
                .Include(p => p.Manufacturer)
                .Include(p => p.ProductType)
                .Include(p => p.UnitOfMeasure)
                .ToList();
        }

        public Product? GetProduct(int id)
        {
            return _dbContext
                .Products
                .Include(p => p.Manufacturer)
                .Include(p => p.ProductType)
                .Include (p => p.UnitOfMeasure)
                .SingleOrDefault(p => p.Id == id);
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product;
        }

        public Product UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();

            return product;
        }

        public Product? DeleteProduct(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p=> p.Id == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();

                return product;
            }

            return null;
        }
    }
}
