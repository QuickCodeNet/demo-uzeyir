using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.AccountStatement;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.AccountStatement
{
    public partial class AccountStatementService : IAccountStatementService
    {
        private readonly ILogger<AccountStatementService> _logger;
        private readonly IAccountStatementRepository _repository;
        public AccountStatementService(ILogger<AccountStatementService> logger, IAccountStatementRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AccountStatementDto>> InsertAsync(AccountStatementDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AccountStatementDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AccountStatementDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AccountStatementDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AccountStatementDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByAccountIdResponseDto>>> GetByAccountIdAsync(int accountStatementAccountId, int? page, int? size)
        {
            var returnValue = await _repository.GetByAccountIdAsync(accountStatementAccountId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByDateRangeResponseDto>>> GetByDateRangeAsync(int accountStatementAccountId, DateTime accountStatementGeneratedDateFrom, DateTime accountStatementGeneratedDateTo, int? page, int? size)
        {
            var returnValue = await _repository.GetByDateRangeAsync(accountStatementAccountId, accountStatementGeneratedDateFrom, accountStatementGeneratedDateTo, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeleteStatementAsync(int accountStatementId)
        {
            var returnValue = await _repository.DeleteStatementAsync(accountStatementId);
            return returnValue.ToResponse();
        }
    }
}