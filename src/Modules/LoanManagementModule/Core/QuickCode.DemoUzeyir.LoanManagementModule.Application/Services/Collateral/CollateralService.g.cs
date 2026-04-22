using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.Collateral;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.Collateral
{
    public partial class CollateralService : ICollateralService
    {
        private readonly ILogger<CollateralService> _logger;
        private readonly ICollateralRepository _repository;
        public CollateralService(ILogger<CollateralService> logger, ICollateralRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CollateralDto>> InsertAsync(CollateralDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CollateralDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CollateralDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CollateralDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CollateralDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByApplicationIdResponseDto>>> GetByApplicationIdAsync(int collateralLoanApplicationId, int? page, int? size)
        {
            var returnValue = await _repository.GetByApplicationIdAsync(collateralLoanApplicationId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCollateralsWithTypeResponseDto>>> GetCollateralsWithTypeAsync(int collateralsLoanApplicationId, int collateralsCollateralTypeId, int collateralTypesId, int? page, int? size)
        {
            var returnValue = await _repository.GetCollateralsWithTypeAsync(collateralsLoanApplicationId, collateralsCollateralTypeId, collateralTypesId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateMarketValueAsync(int collateralId, UpdateMarketValueRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateMarketValueAsync(collateralId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}