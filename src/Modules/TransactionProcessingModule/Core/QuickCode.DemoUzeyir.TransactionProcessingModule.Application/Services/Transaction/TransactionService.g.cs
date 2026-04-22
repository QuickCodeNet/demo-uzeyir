using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.Transaction;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.Transaction
{
    public partial class TransactionService : ITransactionService
    {
        private readonly ILogger<TransactionService> _logger;
        private readonly ITransactionRepository _repository;
        public TransactionService(ILogger<TransactionService> logger, ITransactionRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<TransactionDto>> InsertAsync(TransactionDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(TransactionDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(long id, TransactionDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<TransactionDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<TransactionDto>> GetItemAsync(long id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(long id)
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

        public async Task<Response<GetByReferenceResponseDto>> GetByReferenceAsync(Guid transactionTransactionReference)
        {
            var returnValue = await _repository.GetByReferenceAsync(transactionTransactionReference);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetBySourceAccountResponseDto>>> GetBySourceAccountAsync(int? transactionSourceAccountId, int? page, int? size)
        {
            var returnValue = await _repository.GetBySourceAccountAsync(transactionSourceAccountId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByDestinationAccountResponseDto>>> GetByDestinationAccountAsync(int? transactionDestinationAccountId, int? page, int? size)
        {
            var returnValue = await _repository.GetByDestinationAccountAsync(transactionDestinationAccountId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByDateRangeResponseDto>>> GetByDateRangeAsync(int? transactionSourceAccountId, DateTime transactionTransactionDateFrom, DateTime transactionTransactionDateTo, int? page, int? size)
        {
            var returnValue = await _repository.GetByDateRangeAsync(transactionSourceAccountId, transactionTransactionDateFrom, transactionTransactionDateTo, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetTransactionsWithDetailsResponseDto>>> GetTransactionsWithDetailsAsync(int? transactionsSourceAccountId, int transactionTransactionTypeId, int transactionTransactionChannelId, int transactionTypeId, int transactionChannelId, int? page, int? size)
        {
            var returnValue = await _repository.GetTransactionsWithDetailsAsync(transactionsSourceAccountId, transactionTransactionTypeId, transactionTransactionChannelId, transactionTypeId, transactionChannelId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetFailedTransactionsResponseDto>>> GetFailedTransactionsAsync(TransactionStatus transactionStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetFailedTransactionsAsync(transactionStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetDailyVolumeAsync(TransactionStatus transactionStatus)
        {
            var returnValue = await _repository.GetDailyVolumeAsync(transactionStatus);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> CompleteTransactionAsync(long transactionId, CompleteTransactionRequestDto updateRequest)
        {
            var returnValue = await _repository.CompleteTransactionAsync(transactionId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> FailTransactionAsync(long transactionId, FailTransactionRequestDto updateRequest)
        {
            var returnValue = await _repository.FailTransactionAsync(transactionId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ReverseTransactionAsync(long transactionId, ReverseTransactionRequestDto updateRequest)
        {
            var returnValue = await _repository.ReverseTransactionAsync(transactionId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}