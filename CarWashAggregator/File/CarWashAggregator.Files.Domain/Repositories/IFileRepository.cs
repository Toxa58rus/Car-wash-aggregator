using CarWashAggregator.Files.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Files.Domain.Repositories
{
    public interface IFileRepository
    {
        Task<FileModel> GetFileAsync(Guid id);
        Task<Guid> CreateFileAsync(IFormFile file);

    }
}
