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
    public partial interface ITransactionChannelService
    {
        Task<Response<TransactionChannelDto>> InsertAsync(TransactionChannelDto request);
        Task<Response<bool>> DeleteAsync(TransactionChannelDto request);
        Task<Response<bool>> UpdateAsync(int id, TransactionChannelDto request);
        Task<Response<List<TransactionChannelDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<TransactionChannelDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool transactionChannelIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string transactionChannelCode);
        Task<Response<int>> DeactivateAsync(int transactionChannelId, DeactivateRequestDto updateRequest);
    }
}