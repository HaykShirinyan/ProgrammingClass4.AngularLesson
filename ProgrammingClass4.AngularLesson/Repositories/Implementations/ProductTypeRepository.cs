using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;


namespace ProgrammingClass4.AngularLesson.Repositories.Implementations
{
    public class ProductTypeRepository:IProductTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductType> GetAllProductTypes()
        {
            return _dbContext.ProductTypes.ToList();
        }

        public ProductType? GetProductType(int id)
        {
            return _dbContext.ProductTypes.SingleOrDefault(p => p.Id == id);

        }

        public ProductType AddProductType(ProductType productType)
        {
            _dbContext.ProductTypes.Add(productType);
            _dbContext.SaveChanges();
            return productType;
        }

        public ProductType UpdateProductType(ProductType productType)
        {
            _dbContext.ProductTypes.Update(productType);
            _dbContext.SaveChanges();
            return productType;
        }

        public ProductType? DeleteProductType(int id)
        {
            var productType = _dbContext.ProductTypes.SingleOrDefault(p=>p.Id == id);   

            if (productType != null)
            {
                _dbContext.Remove(productType);
                _dbContext.SaveChanges();
                return productType;
            }

            return null;
        }
    }
}