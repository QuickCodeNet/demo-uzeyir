using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.LoanApplication;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.LoanApplication
{
    public partial class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILogger<LoanApplicationService> _logger;
        private readonly ILoanApplicationRepository _repository;
        public LoanApplicationService(ILogger<LoanApplicationService> logger, ILoanApplicationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<LoanApplicationDto>> InsertAsync(LoanApplicationDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(LoanApplicationDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, LoanApplicationDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<LoanApplicationDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<LoanApplicationDto>> GetItemAsync(int id)
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

        public async Task<Response<GetByApplicationNumberResponseDto>> GetByApplicationNumberAsync(Guid loanApplicationApplicationNumber)
        {
            var returnValue = await _repository.GetByApplicationNumberAsync(loanApplicationApplicationNumber);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int loanApplicationCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(loanApplicationCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPendingReviewResponseDto>>> GetPendingReviewAsync(LoanApplicationStatus loanApplicationStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetPendingReviewAsync(loanApplicationStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetApplicationsWithProductResponseDto>>> GetApplicationsWithProductAsync(int loanApplicationsCustomerId, int loanApplicationsLoanProductId, int loanProductsId, int? page, int? size)
        {
            var returnValue = await _repository.GetApplicationsWithProductAsync(loanApplicationsCustomerId, loanApplicationsLoanProductId, loanProductsId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> SubmitApplicationAsync(int loanApplicationId, SubmitApplicationRequestDto updateRequest)
        {
            var returnValue = await _repository.SubmitApplicationAsync(loanApplicationId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ApproveApplicationAsync(int loanApplicationId, ApproveApplicationRequestDto updateRequest)
        {
            var returnValue = await _repository.ApproveApplicationAsync(loanApplicationId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RejectApplicationAsync(int loanApplicationId, RejectApplicationRequestDto updateRequest)
        {
            var returnValue = await _repository.RejectApplicationAsync(loanApplicationId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> WithdrawApplicationAsync(int loanApplicationId, WithdrawApplicationRequestDto updateRequest)
        {
            var returnValue = await _repository.WithdrawApplicationAsync(loanApplicationId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}