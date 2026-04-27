using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.LoanApplication;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.LoanApplication;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Api.Controllers
{
    public partial class LoanApplicationsController : QuickCodeBaseApiController
    {
        private readonly ILoanApplicationService service;
        private readonly ILogger<LoanApplicationsController> logger;
        private readonly IServiceProvider serviceProvider;
        public LoanApplicationsController(ILoanApplicationService service, IServiceProvider serviceProvider, ILogger<LoanApplicationsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LoanApplicationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "LoanApplication", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "LoanApplication") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoanApplicationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "LoanApplication", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LoanApplicationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(LoanApplicationDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "LoanApplication") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, LoanApplicationDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "LoanApplication", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "LoanApplication", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-application-number/{loanApplicationApplicationNumber:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByApplicationNumberResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByApplicationNumberAsync(Guid loanApplicationApplicationNumber)
        {
            var response = await service.GetByApplicationNumberAsync(loanApplicationApplicationNumber);
            if (HandleResponseError(response, logger, "LoanApplication", $"LoanApplicationApplicationNumber: '{loanApplicationApplicationNumber}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-id/{loanApplicationCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerIdAsync(int loanApplicationCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerIdAsync(loanApplicationCustomerId, page, size);
            if (HandleResponseError(response, logger, "LoanApplication", $"LoanApplicationCustomerId: '{loanApplicationCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-pending-review/{loanApplicationStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPendingReviewResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPendingReviewAsync(LoanApplicationStatus loanApplicationStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetPendingReviewAsync(loanApplicationStatus, page, size);
            if (HandleResponseError(response, logger, "LoanApplication", $"LoanApplicationStatus: '{loanApplicationStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-applications-with-product/{loanApplicationsCustomerId:int}/{loanApplicationsLoanProductId:int}/{loanProductsId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetApplicationsWithProductResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetApplicationsWithProductAsync(int loanApplicationsCustomerId, int loanApplicationsLoanProductId, int loanProductsId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetApplicationsWithProductAsync(loanApplicationsCustomerId, loanApplicationsLoanProductId, loanProductsId, page, size);
            if (HandleResponseError(response, logger, "LoanApplication", $"LoanApplicationsCustomerId: '{loanApplicationsCustomerId}', LoanApplicationsLoanProductId: '{loanApplicationsLoanProductId}', LoanProductsId: '{loanProductsId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("submit-application/{loanApplicationId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SubmitApplicationAsync(int loanApplicationId, [FromBody] SubmitApplicationRequestDto updateRequest)
        {
            var response = await service.SubmitApplicationAsync(loanApplicationId, updateRequest);
            if (HandleResponseError(response, logger, "LoanApplication", $"LoanApplicationId: '{loanApplicationId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("approve-application/{loanApplicationId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ApproveApplicationAsync(int loanApplicationId, [FromBody] ApproveApplicationRequestDto updateRequest)
        {
            var response = await service.ApproveApplicationAsync(loanApplicationId, updateRequest);
            if (HandleResponseError(response, logger, "LoanApplication", $"LoanApplicationId: '{loanApplicationId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("reject-application/{loanApplicationId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RejectApplicationAsync(int loanApplicationId, [FromBody] RejectApplicationRequestDto updateRequest)
        {
            var response = await service.RejectApplicationAsync(loanApplicationId, updateRequest);
            if (HandleResponseError(response, logger, "LoanApplication", $"LoanApplicationId: '{loanApplicationId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("withdraw-application/{loanApplicationId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> WithdrawApplicationAsync(int loanApplicationId, [FromBody] WithdrawApplicationRequestDto updateRequest)
        {
            var response = await service.WithdrawApplicationAsync(loanApplicationId, updateRequest);
            if (HandleResponseError(response, logger, "LoanApplication", $"LoanApplicationId: '{loanApplicationId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}