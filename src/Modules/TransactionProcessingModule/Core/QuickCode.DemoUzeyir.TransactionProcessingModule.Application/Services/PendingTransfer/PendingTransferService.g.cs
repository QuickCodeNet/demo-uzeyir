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
    public partial class PendingTransferService : IPendingTransferService
    {
        private readonly ILogger<PendingTransferService> _logger;
        private readonly IPendingTransferRepository _repository;
        public PendingTransferService(ILogger<PendingTransferService> logger, IPendingTransferRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<PendingTransferDto>> InsertAsync(PendingTransferDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(PendingTransferDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, PendingTransferDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<PendingTransferDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<PendingTransferDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetScheduledTransfersResponseDto>>> GetScheduledTransfersAsync(TransferStatus pendingTransferStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetScheduledTransfersAsync(pendingTransferStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPendingApprovalResponseDto>>> GetPendingApprovalAsync(TransferStatus pendingTransferStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetPendingApprovalAsync(pendingTransferStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetBySourceAccountResponseDto>>> GetBySourceAccountAsync(int pendingTransferSourceAccountId, int? page, int? size)
        {
            var returnValue = await _repository.GetBySourceAccountAsync(pendingTransferSourceAccountId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ApproveTransferAsync(int pendingTransferId, ApproveTransferRequestDto updateRequest)
        {
            var returnValue = await _repository.ApproveTransferAsync(pendingTransferId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RejectTransferAsync(int pendingTransferId, RejectTransferRequestDto updateRequest)
        {
            var returnValue = await _repository.RejectTransferAsync(pendingTransferId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> CancelScheduledTransferAsync(int pendingTransferId, TransferStatus pendingTransferStatus)
        {
            var returnValue = await _repository.CancelScheduledTransferAsync(pendingTransferId, pendingTransferStatus);
            return returnValue.ToResponse();
        }
    }
}