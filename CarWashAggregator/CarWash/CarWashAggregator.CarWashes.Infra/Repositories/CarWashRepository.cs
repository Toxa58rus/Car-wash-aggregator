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

        public async Task<int> CountCarWashesAsync()
        {
            return await _context.CarWashes.CountAsync();
        }

        public async Task<Guid> CreateCarWashAsync(CarWash carWash)
        {
            await _context.AddAsync(carWash);
            await _context.SaveChangesAsync();
            return carWash.Id;
        }

        public async Task DeleteCarWashAsync(CarWash carWash)
        {
            _context.Remove(carWash);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarWashByIdAsync(Guid id)
        {
            _context.Remove(await _context.CarWashes.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<CarWash> GetCarWashAsync(Guid id)
        {
            return await _context.CarWashes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CarWash>> GetCarWashesPaginatedAsync(int pageSize, int page)
        {
            return await _context.CarWashes.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<CarWash>> GetCarWashListAsync()
        {
            return await _context.CarWashes.ToListAsync();
        }

        public async Task UpdateCarWashAsync(CarWash carWash)
        {
            _context.Attach(carWash);
            _context.Update(carWash);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarWashRatingAsync(Guid carWashId, double AVG_Rating)
        {
            CarWash carWash = await _context.CarWashes.Where(x => x.Id == carWashId).FirstOrDefaultAsync();
            carWash.AVG_Rating = AVG_Rating;
            _context.Update(carWash);
            await _context.SaveChangesAsync();
        }
    }
}
