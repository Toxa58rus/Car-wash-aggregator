using CarWashAggregator.CarWashes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.Domain.Interfaces
{
    public interface ICarWashService
    {
        Task<CarWash> GetCarWashAsync(Guid id);
        Task<IEnumerable<CarWash>> GetCarWashesAsync();
        Task<IEnumerable<CarWash>> GetCarWashesPaginatedAsync(int pageSize, int page);
        Task<int> CountCarWashesAsync();
        Task<Guid> CreateCarWashAsync(CarWash carWash);
        Task UpdateCarWashAsync(CarWash carWash);
        Task UpdateCarWashRatingAsync(Guid carWashId, double AVG_Rating);
        Task DeleteCarWashAsync(CarWash carWash);
        Task DeleteCarWashByIdAsync(Guid id);
    }
}
