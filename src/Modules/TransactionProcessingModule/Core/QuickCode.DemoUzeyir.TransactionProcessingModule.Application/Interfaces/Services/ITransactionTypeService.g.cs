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
    public partial interface ITransactionTypeService
    {
        Task<Response<TransactionTypeDto>> InsertAsync(TransactionTypeDto request);
        Task<Response<bool>> DeleteAsync(TransactionTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, TransactionTypeDto request);
        Task<Response<List<TransactionTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TransactionTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool transactionTypeIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string transactionTypeCode);
        Task<Response<int>> DeactivateAsync(int transactionTypeId, DeactivateRequestDto updateRequest);
    }
}