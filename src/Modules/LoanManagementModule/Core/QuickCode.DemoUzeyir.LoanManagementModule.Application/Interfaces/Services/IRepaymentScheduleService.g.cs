using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.RepaymentSchedule;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.RepaymentSchedule
{
    public partial interface IRepaymentScheduleService
    {
        Task<Response<RepaymentScheduleDto>> InsertAsync(RepaymentScheduleDto request);
        Task<Response<bool>> DeleteAsync(RepaymentScheduleDto request);
        Task<Response<bool>> UpdateAsync(int id, RepaymentScheduleDto request);
        Task<Response<List<RepaymentScheduleDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RepaymentScheduleDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByLoanIdResponseDto>>> GetByLoanIdAsync(int repaymentScheduleLoanId, int? page, int? size);
        Task<Response<List<GetUpcomingPaymentsResponseDto>>> GetUpcomingPaymentsAsync(int repaymentScheduleLoanId, PaymentStatus repaymentScheduleStatus, int? page, int? size);
        Task<Response<List<GetOverduePaymentsResponseDto>>> GetOverduePaymentsAsync(int repaymentScheduleLoanId, PaymentStatus repaymentScheduleStatus, int? page, int? size);
        Task<Response<int>> MarkAsPaidAsync(int repaymentScheduleId, MarkAsPaidRequestDto updateRequest);
    }
}