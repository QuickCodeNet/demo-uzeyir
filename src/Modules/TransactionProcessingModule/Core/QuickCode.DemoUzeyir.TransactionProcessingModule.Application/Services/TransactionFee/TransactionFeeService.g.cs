using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.TransactionFee;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.TransactionFee
{
    public partial class TransactionFeeService : ITransactionFeeService
    {
        private readonly ILogger<TransactionFeeService> _logger;
        private readonly ITransactionFeeRepository _repository;
        public TransactionFeeService(ILogger<TransactionFeeService> logger, ITransactionFeeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TransactionFeeDto>> InsertAsync(TransactionFeeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TransactionFeeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, TransactionFeeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TransactionFeeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TransactionFeeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetFeesByTransactionIdResponseDto>>> GetFeesByTransactionIdAsync(long transactionFeeTransactionId, int? page, int? size)
        {
            var returnValue = await _repository.GetFeesByTransactionIdAsync(transactionFeeTransactionId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetFeesWithDetailsResponseDto>>> GetFeesWithDetailsAsync(long transactionFeesTransactionId, int transactionFeeFeeTypeId, int feeTypeId, int? page, int? size)
        {
            var returnValue = await _repository.GetFeesWithDetailsAsync(transactionFeesTransactionId, transactionFeeFeeTypeId, feeTypeId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetTotalFeesByTypeAsync(DateTime transactionFeeAppliedDateFrom, DateTime transactionFeeAppliedDateTo)
        {
            var returnValue = await _repository.GetTotalFeesByTypeAsync(transactionFeeAppliedDateFrom, transactionFeeAppliedDateTo);
            return returnValue.ToResponse();
        }
    }
}