using CarWashAggregator.Files.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Files.Domain.Interfaces
{
    public interface IFileService
    {
        Task<FileModel> GetFileAsync(Guid id);
        Task<Guid> CreateFileAsync(IFormFile file);
    }
}
