using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.TransactionType;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.TransactionType
{
    public partial class TransactionTypeService : ITransactionTypeService
    {
        private readonly ILogger<TransactionTypeService> _logger;
        private readonly ITransactionTypeRepository _repository;
        public TransactionTypeService(ILogger<TransactionTypeService> logger, ITransactionTypeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TransactionTypeDto>> InsertAsync(TransactionTypeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TransactionTypeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TransactionTypeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TransactionTypeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TransactionTypeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool transactionTypeIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(transactionTypeIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string transactionTypeCode)
        {
            var returnValue = await _repository.GetByCodeAsync(transactionTypeCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int transactionTypeId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(transactionTypeId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}