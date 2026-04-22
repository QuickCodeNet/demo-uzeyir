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
    public partial interface ITransactionService
    {
        Task<Response<TransactionDto>> InsertAsync(TransactionDto request);
        Task<Response<bool>> DeleteAsync(TransactionDto request);
        Task<Response<bool>> UpdateAsync(long id, TransactionDto request);
        Task<Response<List<TransactionDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TransactionDto>> GetItemAsync(long id);
        Task<Response<bool>> DeleteItemAsync(long id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByReferenceResponseDto>> GetByReferenceAsync(Guid transactionTransactionReference);
        Task<Response<List<GetBySourceAccountResponseDto>>> GetBySourceAccountAsync(int? transactionSourceAccountId, int? page, int? size);
        Task<Response<List<GetByDestinationAccountResponseDto>>> GetByDestinationAccountAsync(int? transactionDestinationAccountId, int? page, int? size);
        Task<Response<List<GetByDateRangeResponseDto>>> GetByDateRangeAsync(int? transactionSourceAccountId, DateTime transactionTransactionDateFrom, DateTime transactionTransactionDateTo, int? page, int? size);
        Task<Response<List<GetTransactionsWithDetailsResponseDto>>> GetTransactionsWithDetailsAsync(int? transactionsSourceAccountId, int transactionTransactionTypeId, int transactionTransactionChannelId, int transactionTypeId, int transactionChannelId, int? page, int? size);
        Task<Response<List<GetFailedTransactionsResponseDto>>> GetFailedTransactionsAsync(TransactionStatus transactionStatus, int? page, int? size);
        Task<Response<long>> GetDailyVolumeAsync(TransactionStatus transactionStatus);
        Task<Response<int>> CompleteTransactionAsync(long transactionId, CompleteTransactionRequestDto updateRequest);
        Task<Response<int>> FailTransactionAsync(long transactionId, FailTransactionRequestDto updateRequest);
        Task<Response<int>> ReverseTransactionAsync(long transactionId, ReverseTransactionRequestDto updateRequest);
    }
}