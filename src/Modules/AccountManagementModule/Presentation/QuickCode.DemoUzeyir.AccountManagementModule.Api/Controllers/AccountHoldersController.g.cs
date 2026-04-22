using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.AccountHolder;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.AccountHolder;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Api.Controllers
{
    public partial class AccountHoldersController : QuickCodeBaseApiController
    {
        private readonly IAccountHolderService service;
        private readonly ILogger<AccountHoldersController> logger;
        private readonly IServiceProvider serviceProvider;
        public AccountHoldersController(IAccountHolderService service, IServiceProvider serviceProvider, ILogger<AccountHoldersController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AccountHolderDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "AccountHolder", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "AccountHolder") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{accountId:int}/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountHolderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int accountId, int customerId)
        {
            var response = await service.GetItemAsync(accountId, customerId);
            if (HandleResponseError(response, logger, "AccountHolder", $"AccountId: '{accountId}', CustomerId: '{customerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AccountHolderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(AccountHolderDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "AccountHolder") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { accountId = response.Value.AccountId, customerId = response.Value.CustomerId }, response.Value);
        }

        [HttpPut("{accountId:int}/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int accountId, int customerId, AccountHolderDto model)
        {
            if (!(model.AccountId == accountId && model.CustomerId == customerId))
            {
                return BadRequest($"AccountId: '{accountId}', CustomerId: '{customerId}' must be equal to model.AccountId: '{model.AccountId}', model.CustomerId: '{model.CustomerId}'");
            }

            var response = await service.UpdateAsync(accountId, customerId, model);
            if (HandleResponseError(response, logger, "AccountHolder", $"AccountId: '{accountId}', CustomerId: '{customerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{accountId:int}/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(int accountId, int customerId)
        {
            var response = await service.DeleteItemAsync(accountId, customerId);
            if (HandleResponseError(response, logger, "AccountHolder", $"AccountId: '{accountId}', CustomerId: '{customerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-holders-by-account-id/{accountHolderAccountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetHoldersByAccountIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetHoldersByAccountIdAsync(int accountHolderAccountId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetHoldersByAccountIdAsync(accountHolderAccountId, page, size);
            if (HandleResponseError(response, logger, "AccountHolder", $"AccountHolderAccountId: '{accountHolderAccountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-accounts-by-holder-id/{accountHolderCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAccountsByHolderIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetAccountsByHolderIdAsync(int accountHolderCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetAccountsByHolderIdAsync(accountHolderCustomerId, page, size);
            if (HandleResponseError(response, logger, "AccountHolder", $"AccountHolderCustomerId: '{accountHolderCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("remove-holder/{accountHolderAccountId:int}/{accountHolderCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RemoveHolderAsync(int accountHolderAccountId, int accountHolderCustomerId)
        {
            var response = await service.RemoveHolderAsync(accountHolderAccountId, accountHolderCustomerId);
            if (HandleResponseError(response, logger, "AccountHolder", $"AccountHolderAccountId: '{accountHolderAccountId}', AccountHolderCustomerId: '{accountHolderCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}