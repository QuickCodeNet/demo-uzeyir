using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.FeeType;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.FeeType
{
    public partial class FeeTypeService : IFeeTypeService
    {
        private readonly ILogger<FeeTypeService> _logger;
        private readonly IFeeTypeRepository _repository;
        public FeeTypeService(ILogger<FeeTypeService> logger, IFeeTypeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<FeeTypeDto>> InsertAsync(FeeTypeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(FeeTypeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, FeeTypeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<FeeTypeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<FeeTypeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool feeTypeIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(feeTypeIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string feeTypeCode)
        {
            var returnValue = await _repository.GetByCodeAsync(feeTypeCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int feeTypeId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(feeTypeId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}