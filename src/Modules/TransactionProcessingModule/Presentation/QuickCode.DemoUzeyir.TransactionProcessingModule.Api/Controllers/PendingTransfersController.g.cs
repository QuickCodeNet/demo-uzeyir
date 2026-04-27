using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.PendingTransfer;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.PendingTransfer;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Api.Controllers
{
    public partial class PendingTransfersController : QuickCodeBaseApiController
    {
        private readonly IPendingTransferService service;
        private readonly ILogger<PendingTransfersController> logger;
        private readonly IServiceProvider serviceProvider;
        public PendingTransfersController(IPendingTransferService service, IServiceProvider serviceProvider, ILogger<PendingTransfersController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PendingTransferDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "PendingTransfer", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "PendingTransfer") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PendingTransferDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "PendingTransfer", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PendingTransferDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(PendingTransferDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "PendingTransfer") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, PendingTransferDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "PendingTransfer", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "PendingTransfer", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-scheduled-transfers/{pendingTransferStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetScheduledTransfersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetScheduledTransfersAsync(TransferStatus pendingTransferStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetScheduledTransfersAsync(pendingTransferStatus, page, size);
            if (HandleResponseError(response, logger, "PendingTransfer", $"PendingTransferStatus: '{pendingTransferStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-pending-approval/{pendingTransferStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPendingApprovalResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPendingApprovalAsync(TransferStatus pendingTransferStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetPendingApprovalAsync(pendingTransferStatus, page, size);
            if (HandleResponseError(response, logger, "PendingTransfer", $"PendingTransferStatus: '{pendingTransferStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-source-account/{pendingTransferSourceAccountId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetBySourceAccountResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetBySourceAccountAsync(int pendingTransferSourceAccountId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetBySourceAccountAsync(pendingTransferSourceAccountId, page, size);
            if (HandleResponseError(response, logger, "PendingTransfer", $"PendingTransferSourceAccountId: '{pendingTransferSourceAccountId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("approve-transfer/{pendingTransferId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ApproveTransferAsync(int pendingTransferId, [FromBody] ApproveTransferRequestDto updateRequest)
        {
            var response = await service.ApproveTransferAsync(pendingTransferId, updateRequest);
            if (HandleResponseError(response, logger, "PendingTransfer", $"PendingTransferId: '{pendingTransferId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("reject-transfer/{pendingTransferId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RejectTransferAsync(int pendingTransferId, [FromBody] RejectTransferRequestDto updateRequest)
        {
            var response = await service.RejectTransferAsync(pendingTransferId, updateRequest);
            if (HandleResponseError(response, logger, "PendingTransfer", $"PendingTransferId: '{pendingTransferId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("cancel-scheduled-transfer/{pendingTransferId:int}/{pendingTransferStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CancelScheduledTransferAsync(int pendingTransferId, TransferStatus pendingTransferStatus)
        {
            var response = await service.CancelScheduledTransferAsync(pendingTransferId, pendingTransferStatus);
            if (HandleResponseError(response, logger, "PendingTransfer", $"PendingTransferId: '{pendingTransferId}', PendingTransferStatus: '{pendingTransferStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}