using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Files.BL.Queries;
using CarWashAggregator.Files.Domain.Interfaces;
using CarWashAggregator.Files.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.Files.BL.QueryHandlers
{
    public class RequestByIdHandler : IQueryHandler<FileIdQuery, FileQuery>
    {
        public IFileService _fileService;

        public RequestByIdHandler(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<FileQuery> Handle(FileIdQuery query)
        {
            FileQuery response = new FileQuery() 
            { 
                File = await _fileService.GetFileAsync(query.Id)
            };

            return response;
        }
    }
}
