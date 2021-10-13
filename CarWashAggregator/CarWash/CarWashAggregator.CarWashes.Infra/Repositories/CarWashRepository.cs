using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.CarWashes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.Infra.Repositories
{
    public class CarWashRepository : ICarWashRepository
    {
        private readonly ApplicationContext _context;

        public CarWashRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(CarWash carWash)
        {
            await _context.AddAsync(carWash);
            await _context.SaveChangesAsync();
            return carWash.Id;
        }

        public IEnumerable<CarWash> GetCarWashList()
        {
            return _context.CarWashes;
        }
    }
}
