using CarWashAggregator.Files.Domain.Interfaces;
using CarWashAggregator.Files.Domain.Models;
using CarWashAggregator.Files.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Files.BL.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _repository;

        public FileService(IFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateFileAsync(IFormFile file)
        {
            return await _repository.CreateFileAsync(file);
        }

        public async Task<FileModel> GetFileAsync(Guid id)
        {
            return await _repository.GetFileAsync(id);
        }
    }
}
