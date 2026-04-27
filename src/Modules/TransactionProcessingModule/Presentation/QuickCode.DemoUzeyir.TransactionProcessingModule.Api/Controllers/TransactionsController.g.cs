using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.Transaction;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.Transaction;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Api.Controllers
{
    public partial class TransactionsController : QuickCodeBaseApiController
    {
        private readonly ITransactionService service;
        private readonly ILogger<TransactionsController> logger;
        private readonly IServiceProvider serviceProvider;
        public TransactionsController(ITransactionService service, IServiceProvider serviceProvider, ILogger<TransactionsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TransactionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Transaction", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Transaction") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(long id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Transaction", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TransactionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(TransactionDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Transaction") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(long id, TransactionDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Transaction", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await service.DeleteItemAsync(id);
            if (HandleResponseError(response, logger, "Transaction", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-reference/{transactionTransactionReference:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByReferenceResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByReferenceAsync(Guid transactionTransactionReference)
        {
            var response = await service.GetByReferenceAsync(transactionTransactionReference);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionTransactionReference: '{transactionTransactionReference}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-source-account/{transactionSourceAccountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetBySourceAccountResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetBySourceAccountAsync(int transactionSourceAccountId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetBySourceAccountAsync(transactionSourceAccountId, page, size);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionSourceAccountId: '{transactionSourceAccountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-destination-account/{transactionDestinationAccountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByDestinationAccountResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByDestinationAccountAsync(int transactionDestinationAccountId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByDestinationAccountAsync(transactionDestinationAccountId, page, size);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionDestinationAccountId: '{transactionDestinationAccountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-date-range/{transactionSourceAccountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByDateRangeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByDateRangeAsync(int transactionSourceAccountId, DateTime transactionTransactionDateFrom, DateTime transactionTransactionDateTo, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByDateRangeAsync(transactionSourceAccountId, transactionTransactionDateFrom, transactionTransactionDateTo, page, size);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionSourceAccountId: '{transactionSourceAccountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-transactions-with-details/{transactionsSourceAccountId:int}/{transactionTransactionTypeId:int}/{transactionTransactionChannelId:int}/{transactionTypeId:int}/{transactionChannelId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTransactionsWithDetailsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetTransactionsWithDetailsAsync(int transactionsSourceAccountId, int transactionTransactionTypeId, int transactionTransactionChannelId, int transactionTypeId, int transactionChannelId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetTransactionsWithDetailsAsync(transactionsSourceAccountId, transactionTransactionTypeId, transactionTransactionChannelId, transactionTypeId, transactionChannelId, page, size);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionsSourceAccountId: '{transactionsSourceAccountId}', TransactionTransactionTypeId: '{transactionTransactionTypeId}', TransactionTransactionChannelId: '{transactionTransactionChannelId}', TransactionTypeId: '{transactionTypeId}', TransactionChannelId: '{transactionChannelId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-failed-transactions/{transactionStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetFailedTransactionsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetFailedTransactionsAsync(TransactionStatus transactionStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetFailedTransactionsAsync(transactionStatus, page, size);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionStatus: '{transactionStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-daily-volume/{transactionStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDailyVolumeAsync(TransactionStatus transactionStatus)
        {
            var response = await service.GetDailyVolumeAsync(transactionStatus);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionStatus: '{transactionStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("complete-transaction/{transactionId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CompleteTransactionAsync(long transactionId, [FromBody] CompleteTransactionRequestDto updateRequest)
        {
            var response = await service.CompleteTransactionAsync(transactionId, updateRequest);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionId: '{transactionId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("fail-transaction/{transactionId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> FailTransactionAsync(long transactionId, [FromBody] FailTransactionRequestDto updateRequest)
        {
            var response = await service.FailTransactionAsync(transactionId, updateRequest);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionId: '{transactionId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("reverse-transaction/{transactionId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ReverseTransactionAsync(long transactionId, [FromBody] ReverseTransactionRequestDto updateRequest)
        {
            var response = await service.ReverseTransactionAsync(transactionId, updateRequest);
            if (HandleResponseError(response, logger, "Transaction", $"TransactionId: '{transactionId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}