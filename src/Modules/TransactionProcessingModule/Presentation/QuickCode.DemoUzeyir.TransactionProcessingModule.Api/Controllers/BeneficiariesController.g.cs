using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.Beneficiary;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.Beneficiary;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Api.Controllers
{
    public partial class BeneficiariesController : QuickCodeBaseApiController
    {
        private readonly IBeneficiaryService service;
        private readonly ILogger<BeneficiariesController> logger;
        private readonly IServiceProvider serviceProvider;
        public BeneficiariesController(IBeneficiaryService service, IServiceProvider serviceProvider, ILogger<BeneficiariesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiaryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Beneficiary", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Beneficiary") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BeneficiaryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Beneficiary", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BeneficiaryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(BeneficiaryDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Beneficiary") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, BeneficiaryDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Beneficiary", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Beneficiary", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-id/{beneficiaryCustomerId:int}/{beneficiaryIsActive:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerIdAsync(int beneficiaryCustomerId, bool beneficiaryIsActive, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerIdAsync(beneficiaryCustomerId, beneficiaryIsActive, page, size);
            if (HandleResponseError(response, logger, "Beneficiary", $"BeneficiaryCustomerId: '{beneficiaryCustomerId}', BeneficiaryIsActive: '{beneficiaryIsActive}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-nickname/{beneficiaryCustomerId:int}/{beneficiaryNickname}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByNicknameResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByNicknameAsync(int beneficiaryCustomerId, string beneficiaryNickname, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByNicknameAsync(beneficiaryCustomerId, beneficiaryNickname, page, size);
            if (HandleResponseError(response, logger, "Beneficiary", $"BeneficiaryCustomerId: '{beneficiaryCustomerId}', BeneficiaryNickname: '{beneficiaryNickname}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("deactivate/{beneficiaryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeactivateAsync(int beneficiaryId, [FromBody] DeactivateRequestDto updateRequest)
        {
            var response = await service.DeactivateAsync(beneficiaryId, updateRequest);
            if (HandleResponseError(response, logger, "Beneficiary", $"BeneficiaryId: '{beneficiaryId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}