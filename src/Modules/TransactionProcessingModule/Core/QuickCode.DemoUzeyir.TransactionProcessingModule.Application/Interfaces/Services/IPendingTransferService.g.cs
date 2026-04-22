using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.PendingTransfer;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.PendingTransfer
{
    public partial interface IPendingTransferService
    {
        Task<Response<PendingTransferDto>> InsertAsync(PendingTransferDto request);
        Task<Response<bool>> DeleteAsync(PendingTransferDto request);
        Task<Response<bool>> UpdateAsync(int id, PendingTransferDto request);
        Task<Response<List<PendingTransferDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<PendingTransferDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetScheduledTransfersResponseDto>>> GetScheduledTransfersAsync(TransferStatus pendingTransferStatus, int? page, int? size);
        Task<Response<List<GetPendingApprovalResponseDto>>> GetPendingApprovalAsync(TransferStatus pendingTransferStatus, int? page, int? size);
        Task<Response<List<GetBySourceAccountResponseDto>>> GetBySourceAccountAsync(int pendingTransferSourceAccountId, int? page, int? size);
        Task<Response<int>> ApproveTransferAsync(int pendingTransferId, ApproveTransferRequestDto updateRequest);
        Task<Response<int>> RejectTransferAsync(int pendingTransferId, RejectTransferRequestDto updateRequest);
        Task<Response<int>> CancelScheduledTransferAsync(int pendingTransferId, TransferStatus pendingTransferStatus);
    }
}