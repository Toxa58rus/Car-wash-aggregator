using CarWashAggregator.CarWashes.BL.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.CarWashes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.Services
{
    public class CarWashService : ICarWashService
    {
        private readonly ICarWashRepository _carWashRepository;

        public CarWashService(ICarWashRepository carWashRepository)
        {
            _carWashRepository = carWashRepository;
        }

        public IEnumerable<CarWash> GetCarWashes()
        {
            return _carWashRepository.GetCarWashList();
        }

        public async Task<Guid> CreateCarWashAsync(CarWash carWash)
        {
            await _carWashRepository.CreateAsync(carWash);
            return carWash.Id;
        }
    }
}
