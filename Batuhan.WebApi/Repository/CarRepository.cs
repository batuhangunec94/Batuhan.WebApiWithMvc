using Batuhan.WebApi.Entities;
using Batuhan.WebApi.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batuhan.WebApi.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly ApiDbContext _Context;
        public CarRepository(ApiDbContext apiDbContext)
        {
            _Context = apiDbContext;
        }

        public async Task<bool> CreateCarAsync(Car entity)
        {
            if (entity != null)
            {
                await _Context.Cars.AddAsync(entity);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<List<Car>> GetAllCarAsync()
        {
            return await _Context.Cars.AsNoTracking().ToListAsync();
        }

        public async Task<Car> GetByIdCarAsync(int id)
        {
            return await _Context.Cars.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveCarAsync(int id)
        {
            var entity = await _Context.Cars.FindAsync(id);
            if (entity != null)
            {
                _Context.Cars.Remove(entity);
                await _Context.SaveChangesAsync();
            }
        }

        public async Task UpdateCarAsync(Car entity)
        {
            var unChangedEnttiy = await _Context.Cars.FindAsync(entity.Id);
            if (unChangedEnttiy != null)
            {
                _Context.Entry(unChangedEnttiy).CurrentValues.SetValues(entity);
                await _Context.SaveChangesAsync();
            }

        }
    }
}
