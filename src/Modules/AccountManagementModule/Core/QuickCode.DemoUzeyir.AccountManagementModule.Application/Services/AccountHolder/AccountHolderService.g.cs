using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.AccountHolder;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.AccountHolder
{
    public partial class AccountHolderService : IAccountHolderService
    {
        private readonly ILogger<AccountHolderService> _logger;
        private readonly IAccountHolderRepository _repository;
        public AccountHolderService(ILogger<AccountHolderService> logger, IAccountHolderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AccountHolderDto>> InsertAsync(AccountHolderDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AccountHolderDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int accountId, int customerId, AccountHolderDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.AccountId, request.CustomerId);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AccountHolderDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AccountHolderDto>> GetItemAsync(int accountId, int customerId)
        {
            var returnValue = await _repository.GetByPkAsync(accountId, customerId);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int accountId, int customerId)
        {
            var deleteItem = await _repository.GetByPkAsync(accountId, customerId);
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

        public async Task<Response<List<GetHoldersByAccountIdResponseDto>>> GetHoldersByAccountIdAsync(int accountHolderAccountId, int? page, int? size)
        {
            var returnValue = await _repository.GetHoldersByAccountIdAsync(accountHolderAccountId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAccountsByHolderIdResponseDto>>> GetAccountsByHolderIdAsync(int accountHolderCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetAccountsByHolderIdAsync(accountHolderCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RemoveHolderAsync(int accountHolderAccountId, int accountHolderCustomerId)
        {
            var returnValue = await _repository.RemoveHolderAsync(accountHolderAccountId, accountHolderCustomerId);
            return returnValue.ToResponse();
        }
    }
}