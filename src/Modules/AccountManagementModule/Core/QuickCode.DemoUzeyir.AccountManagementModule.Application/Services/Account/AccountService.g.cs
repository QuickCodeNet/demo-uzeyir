using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.Account;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.Account
{
    public partial class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IAccountRepository _repository;
        public AccountService(ILogger<AccountService> logger, IAccountRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AccountDto>> InsertAsync(AccountDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AccountDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AccountDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AccountDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AccountDto>> GetItemAsync(int id)
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

        public async Task<Response<GetByAccountNumberResponseDto>> GetByAccountNumberAsync(string accountAccountNumber)
        {
            var returnValue = await _repository.GetByAccountNumberAsync(accountAccountNumber);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int accountCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(accountCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetAccountsWithDetailsResponseDto>>> GetAccountsWithDetailsAsync(int accountsCustomerId, int accountAccountTypeId, int accountCurrencyId, int accountTypeId, int currencyId, int? page, int? size)
        {
            var returnValue = await _repository.GetAccountsWithDetailsAsync(accountsCustomerId, accountAccountTypeId, accountCurrencyId, accountTypeId, currencyId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetLowBalanceAccountsResponseDto>>> GetLowBalanceAccountsAsync(AccountStatus accountStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetLowBalanceAccountsAsync(accountStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetDormantAccountsResponseDto>>> GetDormantAccountsAsync(AccountStatus accountStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetDormantAccountsAsync(accountStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetTotalBalanceByCustomerAsync(int accountCustomerId, AccountStatus accountStatus)
        {
            var returnValue = await _repository.GetTotalBalanceByCustomerAsync(accountCustomerId, accountStatus);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ApproveAccountAsync(int accountId, ApproveAccountRequestDto updateRequest)
        {
            var returnValue = await _repository.ApproveAccountAsync(accountId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> FreezeAccountAsync(int accountId, FreezeAccountRequestDto updateRequest)
        {
            var returnValue = await _repository.FreezeAccountAsync(accountId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> CloseAccountAsync(int accountId, CloseAccountRequestDto updateRequest)
        {
            var returnValue = await _repository.CloseAccountAsync(accountId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateBalanceAsync(int accountId, UpdateBalanceRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateBalanceAsync(accountId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}