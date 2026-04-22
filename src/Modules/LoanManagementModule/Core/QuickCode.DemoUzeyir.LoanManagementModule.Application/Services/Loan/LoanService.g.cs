using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.Loan;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.Loan
{
    public partial class LoanService : ILoanService
    {
        private readonly ILogger<LoanService> _logger;
        private readonly ILoanRepository _repository;
        public LoanService(ILogger<LoanService> logger, ILoanRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<LoanDto>> InsertAsync(LoanDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(LoanDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, LoanDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<LoanDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<LoanDto>> GetItemAsync(int id)
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

        public async Task<Response<GetByAccountNumberResponseDto>> GetByAccountNumberAsync(string loanLoanAccountNumber)
        {
            var returnValue = await _repository.GetByAccountNumberAsync(loanLoanAccountNumber);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int loanCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(loanCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetActiveLoansResponseDto>>> GetActiveLoansAsync(LoanStatus loanStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveLoansAsync(loanStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetDefaultedLoansResponseDto>>> GetDefaultedLoansAsync(LoanStatus loanStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetDefaultedLoansAsync(loanStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetTotalOutstandingLoansAsync(LoanStatus loanStatus)
        {
            var returnValue = await _repository.GetTotalOutstandingLoansAsync(loanStatus);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateOutstandingBalanceAsync(int loanId, UpdateOutstandingBalanceRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateOutstandingBalanceAsync(loanId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkAsPaidOffAsync(int loanId, MarkAsPaidOffRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkAsPaidOffAsync(loanId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkAsDefaultedAsync(int loanId, MarkAsDefaultedRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkAsDefaultedAsync(loanId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}