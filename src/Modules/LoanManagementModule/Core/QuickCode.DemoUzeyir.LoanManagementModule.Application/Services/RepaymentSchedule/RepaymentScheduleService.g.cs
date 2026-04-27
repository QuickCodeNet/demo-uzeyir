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
    public partial class RepaymentScheduleService : IRepaymentScheduleService
    {
        private readonly ILogger<RepaymentScheduleService> _logger;
        private readonly IRepaymentScheduleRepository _repository;
        public RepaymentScheduleService(ILogger<RepaymentScheduleService> logger, IRepaymentScheduleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<RepaymentScheduleDto>> InsertAsync(RepaymentScheduleDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(RepaymentScheduleDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, RepaymentScheduleDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<RepaymentScheduleDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<RepaymentScheduleDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByLoanIdResponseDto>>> GetByLoanIdAsync(int repaymentScheduleLoanId, int? page, int? size)
        {
            var returnValue = await _repository.GetByLoanIdAsync(repaymentScheduleLoanId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetUpcomingPaymentsResponseDto>>> GetUpcomingPaymentsAsync(int repaymentScheduleLoanId, PaymentStatus repaymentScheduleStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetUpcomingPaymentsAsync(repaymentScheduleLoanId, repaymentScheduleStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetOverduePaymentsResponseDto>>> GetOverduePaymentsAsync(int repaymentScheduleLoanId, PaymentStatus repaymentScheduleStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetOverduePaymentsAsync(repaymentScheduleLoanId, repaymentScheduleStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkAsPaidAsync(int repaymentScheduleId, MarkAsPaidRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkAsPaidAsync(repaymentScheduleId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}