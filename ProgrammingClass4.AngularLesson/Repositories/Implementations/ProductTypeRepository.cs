using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;

namespace ProgrammingClass4.AngularLesson.Repositories.Implementations
{
    public class ProductTypeRepository : IProductTypeRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public  ProductTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProductType>> GetAllAsync()
        {
            return await _dbContext.ProductTypes.ToListAsync();
        }

        public async Task<ProductType?> GetAsync(int id)
        {
            return await _dbContext.ProductTypes.FindAsync(id);
        }

        public async Task<ProductType> AddAsync(ProductType productType)
        {
            _dbContext.ProductTypes.Add(productType);
            await _dbContext.SaveChangesAsync();

            return productType;
        }

        public async Task<ProductType> UpdateAsync(ProductType productType)
        {
            _dbContext.ProductTypes.Update(productType);
           await _dbContext.SaveChangesAsync();

            return productType;
        }

        public async Task<ProductType?> DeleteAsync(int id)
        {
            var productType = await _dbContext.ProductTypes.FindAsync(id);

            if (productType != null)
            {
                _dbContext.ProductTypes.Remove(productType);
                await _dbContext.SaveChangesAsync();

                return productType;
            }

            return null;
        }
    }
}
