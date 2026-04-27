using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.AccountType;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.AccountType
{
    public partial class AccountTypeService : IAccountTypeService
    {
        private readonly ILogger<AccountTypeService> _logger;
        private readonly IAccountTypeRepository _repository;
        public AccountTypeService(ILogger<AccountTypeService> logger, IAccountTypeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<AccountTypeDto>> InsertAsync(AccountTypeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(AccountTypeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, AccountTypeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<AccountTypeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<AccountTypeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool accountTypeIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(accountTypeIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string accountTypeCode)
        {
            var returnValue = await _repository.GetByCodeAsync(accountTypeCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateInterestRateAsync(int accountTypeId, UpdateInterestRateRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateInterestRateAsync(accountTypeId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int accountTypeId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(accountTypeId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}