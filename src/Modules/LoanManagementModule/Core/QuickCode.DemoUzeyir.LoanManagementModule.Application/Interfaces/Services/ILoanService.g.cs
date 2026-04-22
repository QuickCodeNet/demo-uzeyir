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
    public partial interface ILoanService
    {
        Task<Response<LoanDto>> InsertAsync(LoanDto request);
        Task<Response<bool>> DeleteAsync(LoanDto request);
        Task<Response<bool>> UpdateAsync(int id, LoanDto request);
        Task<Response<List<LoanDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<LoanDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByAccountNumberResponseDto>> GetByAccountNumberAsync(string loanLoanAccountNumber);
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int loanCustomerId, int? page, int? size);
        Task<Response<List<GetActiveLoansResponseDto>>> GetActiveLoansAsync(LoanStatus loanStatus, int? page, int? size);
        Task<Response<List<GetDefaultedLoansResponseDto>>> GetDefaultedLoansAsync(LoanStatus loanStatus, int? page, int? size);
        Task<Response<long>> GetTotalOutstandingLoansAsync(LoanStatus loanStatus);
        Task<Response<int>> UpdateOutstandingBalanceAsync(int loanId, UpdateOutstandingBalanceRequestDto updateRequest);
        Task<Response<int>> MarkAsPaidOffAsync(int loanId, MarkAsPaidOffRequestDto updateRequest);
        Task<Response<int>> MarkAsDefaultedAsync(int loanId, MarkAsDefaultedRequestDto updateRequest);
    }
}