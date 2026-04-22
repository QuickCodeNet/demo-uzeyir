using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.IdentificationDocument;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.IdentificationDocument;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Api.Controllers
{
    public partial class IdentificationDocumentsController : QuickCodeBaseApiController
    {
        private readonly IIdentificationDocumentService service;
        private readonly ILogger<IdentificationDocumentsController> logger;
        private readonly IServiceProvider serviceProvider;
        public IdentificationDocumentsController(IIdentificationDocumentService service, IServiceProvider serviceProvider, ILogger<IdentificationDocumentsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IdentificationDocumentDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "IdentificationDocument", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "IdentificationDocument") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IdentificationDocumentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "IdentificationDocument", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IdentificationDocumentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(IdentificationDocumentDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "IdentificationDocument") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, IdentificationDocumentDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "IdentificationDocument", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "IdentificationDocument", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-id/{identificationDocumentCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerIdAsync(int identificationDocumentCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerIdAsync(identificationDocumentCustomerId, page, size);
            if (HandleResponseError(response, logger, "IdentificationDocument", $"IdentificationDocumentCustomerId: '{identificationDocumentCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-documents-with-type/{identificationDocumentsCustomerId:int}/{identificationDocumentsDocumentTypeId:int}/{documentTypesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetDocumentsWithTypeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetDocumentsWithTypeAsync(int identificationDocumentsCustomerId, int identificationDocumentsDocumentTypeId, int documentTypesId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetDocumentsWithTypeAsync(identificationDocumentsCustomerId, identificationDocumentsDocumentTypeId, documentTypesId, page, size);
            if (HandleResponseError(response, logger, "IdentificationDocument", $"IdentificationDocumentsCustomerId: '{identificationDocumentsCustomerId}', IdentificationDocumentsDocumentTypeId: '{identificationDocumentsDocumentTypeId}', DocumentTypesId: '{documentTypesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-expiring-soon/{identificationDocumentStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetExpiringSoonResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetExpiringSoonAsync(DocumentStatus identificationDocumentStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetExpiringSoonAsync(identificationDocumentStatus, page, size);
            if (HandleResponseError(response, logger, "IdentificationDocument", $"IdentificationDocumentStatus: '{identificationDocumentStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("verify-document/{identificationDocumentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> VerifyDocumentAsync(int identificationDocumentId, [FromBody] VerifyDocumentRequestDto updateRequest)
        {
            var response = await service.VerifyDocumentAsync(identificationDocumentId, updateRequest);
            if (HandleResponseError(response, logger, "IdentificationDocument", $"IdentificationDocumentId: '{identificationDocumentId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("reject-document/{identificationDocumentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RejectDocumentAsync(int identificationDocumentId, [FromBody] RejectDocumentRequestDto updateRequest)
        {
            var response = await service.RejectDocumentAsync(identificationDocumentId, updateRequest);
            if (HandleResponseError(response, logger, "IdentificationDocument", $"IdentificationDocumentId: '{identificationDocumentId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("mark-as-expired/{identificationDocumentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> MarkAsExpiredAsync(int identificationDocumentId, [FromBody] MarkAsExpiredRequestDto updateRequest)
        {
            var response = await service.MarkAsExpiredAsync(identificationDocumentId, updateRequest);
            if (HandleResponseError(response, logger, "IdentificationDocument", $"IdentificationDocumentId: '{identificationDocumentId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}