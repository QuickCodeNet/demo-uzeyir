using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.TransactionFee;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.TransactionFee;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Api.Controllers
{
    public partial class TransactionFeesController : QuickCodeBaseApiController
    {
        private readonly ITransactionFeeService service;
        private readonly ILogger<TransactionFeesController> logger;
        private readonly IServiceProvider serviceProvider;
        public TransactionFeesController(ITransactionFeeService service, IServiceProvider serviceProvider, ILogger<TransactionFeesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TransactionFeeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "TransactionFee", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "TransactionFee") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionFeeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "TransactionFee", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TransactionFeeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(TransactionFeeDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "TransactionFee") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, TransactionFeeDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "TransactionFee", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "TransactionFee", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-fees-by-transaction-id/{transactionFeeTransactionId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetFeesByTransactionIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetFeesByTransactionIdAsync(long transactionFeeTransactionId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetFeesByTransactionIdAsync(transactionFeeTransactionId, page, size);
            if (HandleResponseError(response, logger, "TransactionFee", $"TransactionFeeTransactionId: '{transactionFeeTransactionId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-fees-with-details/{transactionFeesTransactionId:long}/{transactionFeeFeeTypeId:int}/{feeTypeId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetFeesWithDetailsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetFeesWithDetailsAsync(long transactionFeesTransactionId, int transactionFeeFeeTypeId, int feeTypeId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetFeesWithDetailsAsync(transactionFeesTransactionId, transactionFeeFeeTypeId, feeTypeId, page, size);
            if (HandleResponseError(response, logger, "TransactionFee", $"TransactionFeesTransactionId: '{transactionFeesTransactionId}', TransactionFeeFeeTypeId: '{transactionFeeFeeTypeId}', FeeTypeId: '{feeTypeId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-total-fees-by-type")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTotalFeesByTypeAsync(DateTime transactionFeeAppliedDateFrom, DateTime transactionFeeAppliedDateTo)
        {
            var response = await service.GetTotalFeesByTypeAsync(transactionFeeAppliedDateFrom, transactionFeeAppliedDateTo);
            if (HandleResponseError(response, logger, "TransactionFee", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}