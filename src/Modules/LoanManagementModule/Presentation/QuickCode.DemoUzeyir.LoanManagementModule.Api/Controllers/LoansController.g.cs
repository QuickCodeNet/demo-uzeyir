using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.Loan;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.Loan;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Api.Controllers
{
    public partial class LoansController : QuickCodeBaseApiController
    {
        private readonly ILoanService service;
        private readonly ILogger<LoansController> logger;
        private readonly IServiceProvider serviceProvider;
        public LoansController(ILoanService service, IServiceProvider serviceProvider, ILogger<LoansController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LoanDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Loan", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Loan") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoanDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Loan", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LoanDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(LoanDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Loan") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, LoanDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Loan", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Loan", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-account-number/{loanLoanAccountNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByAccountNumberResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByAccountNumberAsync(string loanLoanAccountNumber)
        {
            var response = await service.GetByAccountNumberAsync(loanLoanAccountNumber);
            if (HandleResponseError(response, logger, "Loan", $"LoanLoanAccountNumber: '{loanLoanAccountNumber}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-id/{loanCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerIdAsync(int loanCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerIdAsync(loanCustomerId, page, size);
            if (HandleResponseError(response, logger, "Loan", $"LoanCustomerId: '{loanCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active-loans/{loanStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveLoansResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveLoansAsync(LoanStatus loanStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveLoansAsync(loanStatus, page, size);
            if (HandleResponseError(response, logger, "Loan", $"LoanStatus: '{loanStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-defaulted-loans/{loanStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetDefaultedLoansResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDefaultedLoansAsync(LoanStatus loanStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetDefaultedLoansAsync(loanStatus, page, size);
            if (HandleResponseError(response, logger, "Loan", $"LoanStatus: '{loanStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-total-outstanding-loans/{loanStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTotalOutstandingLoansAsync(LoanStatus loanStatus)
        {
            var response = await service.GetTotalOutstandingLoansAsync(loanStatus);
            if (HandleResponseError(response, logger, "Loan", $"LoanStatus: '{loanStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-outstanding-balance/{loanId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateOutstandingBalanceAsync(int loanId, [FromBody] UpdateOutstandingBalanceRequestDto updateRequest)
        {
            var response = await service.UpdateOutstandingBalanceAsync(loanId, updateRequest);
            if (HandleResponseError(response, logger, "Loan", $"LoanId: '{loanId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("mark-as-paid-off/{loanId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> MarkAsPaidOffAsync(int loanId, [FromBody] MarkAsPaidOffRequestDto updateRequest)
        {
            var response = await service.MarkAsPaidOffAsync(loanId, updateRequest);
            if (HandleResponseError(response, logger, "Loan", $"LoanId: '{loanId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("mark-as-defaulted/{loanId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> MarkAsDefaultedAsync(int loanId, [FromBody] MarkAsDefaultedRequestDto updateRequest)
        {
            var response = await service.MarkAsDefaultedAsync(loanId, updateRequest);
            if (HandleResponseError(response, logger, "Loan", $"LoanId: '{loanId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}