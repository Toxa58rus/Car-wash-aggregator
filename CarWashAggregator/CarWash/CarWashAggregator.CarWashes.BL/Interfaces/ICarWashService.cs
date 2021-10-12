using CarWashAggregator.CarWashes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.Interfaces
{
    public interface ICarWashService
    {
        IEnumerable<CarWash> GetCarWashes();
        Task<Guid> CreateCarWashAsync(CarWash carWash);
    }
}
