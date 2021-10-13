using CarWashAggregator.Files.Domain.Models;
using CarWashAggregator.Files.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarWashAggregator.Files.Infra.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationContext _context;

        public FileRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateFileAsync(IFormFile file)
        {
            FileModel fileModel = new FileModel()
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                ContentLength = (int)file.Length
            };

            using (var reader = new BinaryReader(file.OpenReadStream()))
            {
                fileModel.Content = reader.ReadBytes(fileModel.ContentLength);
            }

            await _context.Files.AddAsync(fileModel);
            await _context.SaveChangesAsync();

            return fileModel.Id;
        }

        public async Task<FileModel> GetFileAsync(Guid id)
        {
            return await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
