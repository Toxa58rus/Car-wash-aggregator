﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface ICarWashService
    {
        Task<List<CarWashModel>> SearchAsync(CarWashSearch query);
        Task<CarWashModel> GetById(Guid id);
        Task<List<CarWashModel>> GetByUserId(Guid userId);
        Task<bool> AddCarWash(CarWashAdd carWash);
    }
}