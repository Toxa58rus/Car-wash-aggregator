using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Files.Domain.Interfaces;
using CarWashAggregator.Files.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAggregator.Files.Deamon.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Page()
        {
            return View();
        }

        public async Task<IActionResult> Index(Guid id)
        {
            FileModel file = await _fileService.GetFileAsync(id);
            return File(file.Content, file.ContentType, file.FileName);
        }

        [HttpPost]
        public async Task<Guid> Upload(IFormFile file)
        {
            return await _fileService.CreateFileAsync(file);
        }
    }
}
