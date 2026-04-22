using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.TransactionChannel;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.TransactionChannel
{
    public partial class TransactionChannelService : ITransactionChannelService
    {
        private readonly ILogger<TransactionChannelService> _logger;
        private readonly ITransactionChannelRepository _repository;
        public TransactionChannelService(ILogger<TransactionChannelService> logger, ITransactionChannelRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TransactionChannelDto>> InsertAsync(TransactionChannelDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TransactionChannelDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TransactionChannelDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TransactionChannelDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TransactionChannelDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool transactionChannelIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(transactionChannelIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string transactionChannelCode)
        {
            var returnValue = await _repository.GetByCodeAsync(transactionChannelCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int transactionChannelId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(transactionChannelId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}