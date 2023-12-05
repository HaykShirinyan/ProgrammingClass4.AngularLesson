using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.AngularLesson.Data;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;

namespace ProgrammingClass4.AngularLesson.Repositories.Implementations
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ManufacturerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Manufacturer>> GetAllAsync()
        { 
            return await _dbContext.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer> GetAsync(int id)
        {
            return await _dbContext.Manufacturers.SingleAsync(m=>m.Id == id);
        }

        public async Task<Manufacturer> AddAsync(Manufacturer manufacturer)
        {
            _dbContext.Manufacturers.Add(manufacturer);
            await _dbContext.SaveChangesAsync();

            return manufacturer;
        }

        public async Task<Manufacturer> UpdateAsync(Manufacturer manufacturer)
        {
            _dbContext.Manufacturers.Update(manufacturer);
            await _dbContext.SaveChangesAsync();

            return manufacturer;
        }
    }
}
