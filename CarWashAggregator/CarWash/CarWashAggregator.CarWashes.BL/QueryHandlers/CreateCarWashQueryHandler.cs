﻿using AutoMapper;
using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.Domain.Models;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWashAggregator.CarWashes.BL.QueryHandlers
{
    public class CreateCarWashQueryHandler : IQueryHandler<RequestCreateCarWashQuery, ResponseCreateCarWashQuery>
    {
        private readonly ICarWashService _carWashService;
        private readonly IMapper _mapper;

        public CreateCarWashQueryHandler(ICarWashService carWashService, IMapper mapper)
        {
            _carWashService = carWashService;
            _mapper = mapper;
        }
        public async Task<ResponseCreateCarWashQuery> Handle(RequestCreateCarWashQuery request)
        {
            CarWash carWash = _mapper.Map<CarWash>(request);

            Guid id = await _carWashService.CreateCarWashAsync(carWash);

            return new ResponseCreateCarWashQuery() { Id = id };
        }
    }
}
