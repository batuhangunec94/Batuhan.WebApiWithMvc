using Batuhan.WebApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Batuhan.WebApi.Interface
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarAsync();
        Task<Car> GetByIdCarAsync(int Id);
        Task<bool> CreateCarAsync(Car entity);
        Task UpdateCarAsync(Car entity);
        Task RemoveCarAsync(int id);
    }
}
