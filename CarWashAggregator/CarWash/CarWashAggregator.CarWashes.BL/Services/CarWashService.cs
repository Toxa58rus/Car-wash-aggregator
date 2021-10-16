using CarWashAggregator.CarWashes.Domain.Interfaces;
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

        public async Task<IEnumerable<CarWash>> GetCarWashesAsync()
        {
            return await _carWashRepository.GetCarWashListAsync();
        }

        public async Task<Guid> CreateCarWashAsync(CarWash carWash)
        {
            await _carWashRepository.CreateCarWashAsync(carWash);
            return carWash.Id;
        }

        public async Task<CarWash> GetCarWashAsync(Guid id)
        {
            return await _carWashRepository.GetCarWashAsync(id);
        }

        public async Task UpdateCarWashAsync(CarWash carWash)
        {
            await _carWashRepository.UpdateCarWashAsync(carWash);
        }

        public async Task DeleteCarWashAsync(CarWash carWash)
        {
            await _carWashRepository.DeleteCarWashAsync(carWash);
        }

        public async Task DeleteCarWashByIdAsync(Guid id)
        {
            await _carWashRepository.DeleteCarWashByIdAsync(id);
        }

        public async Task UpdateCarWashRatingAsync(Guid carWashId, double AVG_Rating)
        {
            await _carWashRepository.UpdateCarWashRatingAsync(carWashId, AVG_Rating);
        }

        public Task<IEnumerable<CarWash>> GetCarWashesPaginatedAsync(int pageSize, int page)
        {
            return _carWashRepository.GetCarWashesPaginatedAsync(pageSize, page);
        }

        public async Task<int> CountCarWashesAsync()
        {
            return await _carWashRepository.CountCarWashesAsync();
        }
    }
}
