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
    public partial interface ITransactionFeeService
    {
        Task<Response<TransactionFeeDto>> InsertAsync(TransactionFeeDto request);
        Task<Response<bool>> DeleteAsync(TransactionFeeDto request);
        Task<Response<bool>> UpdateAsync(int id, TransactionFeeDto request);
        Task<Response<List<TransactionFeeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TransactionFeeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetFeesByTransactionIdResponseDto>>> GetFeesByTransactionIdAsync(long transactionFeeTransactionId, int? page, int? size);
        Task<Response<List<GetFeesWithDetailsResponseDto>>> GetFeesWithDetailsAsync(long transactionFeesTransactionId, int transactionFeeFeeTypeId, int feeTypeId, int? page, int? size);
        Task<Response<long>> GetTotalFeesByTypeAsync(DateTime transactionFeeAppliedDateFrom, DateTime transactionFeeAppliedDateTo);
    }
}