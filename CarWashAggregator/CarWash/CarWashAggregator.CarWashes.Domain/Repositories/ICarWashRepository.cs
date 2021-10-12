using CarWashAggregator.CarWashes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.Domain.Repositories
{
    public interface ICarWashRepository
    {
        IEnumerable<CarWash> GetCarWashList();
        Task<Guid> CreateAsync(CarWash carWash);
    }
}
