using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.Account;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.Account;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Api.Controllers
{
    public partial class AccountsController : QuickCodeBaseApiController
    {
        private readonly IAccountService service;
        private readonly ILogger<AccountsController> logger;
        private readonly IServiceProvider serviceProvider;
        public AccountsController(IAccountService service, IServiceProvider serviceProvider, ILogger<AccountsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AccountDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Account", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Account") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Account", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AccountDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(AccountDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Account") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, AccountDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Account", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await service.DeleteItemAsync(id);
            if (HandleResponseError(response, logger, "Account", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-account-number/{accountAccountNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByAccountNumberResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByAccountNumberAsync(string accountAccountNumber)
        {
            var response = await service.GetByAccountNumberAsync(accountAccountNumber);
            if (HandleResponseError(response, logger, "Account", $"AccountAccountNumber: '{accountAccountNumber}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-id/{accountCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerIdAsync(int accountCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerIdAsync(accountCustomerId, page, size);
            if (HandleResponseError(response, logger, "Account", $"AccountCustomerId: '{accountCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-accounts-with-details/{accountsCustomerId:int}/{accountAccountTypeId:int}/{accountCurrencyId:int}/{accountTypeId:int}/{currencyId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAccountsWithDetailsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAccountsWithDetailsAsync(int accountsCustomerId, int accountAccountTypeId, int accountCurrencyId, int accountTypeId, int currencyId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetAccountsWithDetailsAsync(accountsCustomerId, accountAccountTypeId, accountCurrencyId, accountTypeId, currencyId, page, size);
            if (HandleResponseError(response, logger, "Account", $"AccountsCustomerId: '{accountsCustomerId}', AccountAccountTypeId: '{accountAccountTypeId}', AccountCurrencyId: '{accountCurrencyId}', AccountTypeId: '{accountTypeId}', CurrencyId: '{currencyId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-low-balance-accounts/{accountStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetLowBalanceAccountsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetLowBalanceAccountsAsync(AccountStatus accountStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetLowBalanceAccountsAsync(accountStatus, page, size);
            if (HandleResponseError(response, logger, "Account", $"AccountStatus: '{accountStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-dormant-accounts/{accountStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetDormantAccountsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDormantAccountsAsync(AccountStatus accountStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetDormantAccountsAsync(accountStatus, page, size);
            if (HandleResponseError(response, logger, "Account", $"AccountStatus: '{accountStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-total-balance-by-customer/{accountCustomerId:int}/{accountStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTotalBalanceByCustomerAsync(int accountCustomerId, AccountStatus accountStatus)
        {
            var response = await service.GetTotalBalanceByCustomerAsync(accountCustomerId, accountStatus);
            if (HandleResponseError(response, logger, "Account", $"AccountCustomerId: '{accountCustomerId}', AccountStatus: '{accountStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("approve-account/{accountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ApproveAccountAsync(int accountId, [FromBody] ApproveAccountRequestDto updateRequest)
        {
            var response = await service.ApproveAccountAsync(accountId, updateRequest);
            if (HandleResponseError(response, logger, "Account", $"AccountId: '{accountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("freeze-account/{accountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> FreezeAccountAsync(int accountId, [FromBody] FreezeAccountRequestDto updateRequest)
        {
            var response = await service.FreezeAccountAsync(accountId, updateRequest);
            if (HandleResponseError(response, logger, "Account", $"AccountId: '{accountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("close-account/{accountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CloseAccountAsync(int accountId, [FromBody] CloseAccountRequestDto updateRequest)
        {
            var response = await service.CloseAccountAsync(accountId, updateRequest);
            if (HandleResponseError(response, logger, "Account", $"AccountId: '{accountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-balance/{accountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateBalanceAsync(int accountId, [FromBody] UpdateBalanceRequestDto updateRequest)
        {
            var response = await service.UpdateBalanceAsync(accountId, updateRequest);
            if (HandleResponseError(response, logger, "Account", $"AccountId: '{accountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}