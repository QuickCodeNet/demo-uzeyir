using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.Collateral;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.Collateral;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Api.Controllers
{
    public partial class CollateralsController : QuickCodeBaseApiController
    {
        private readonly ICollateralService service;
        private readonly ILogger<CollateralsController> logger;
        private readonly IServiceProvider serviceProvider;
        public CollateralsController(ICollateralService service, IServiceProvider serviceProvider, ILogger<CollateralsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CollateralDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Collateral", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Collateral") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollateralDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Collateral", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CollateralDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(CollateralDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Collateral") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, CollateralDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Collateral", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Collateral", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-application-id/{collateralLoanApplicationId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByApplicationIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByApplicationIdAsync(int collateralLoanApplicationId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByApplicationIdAsync(collateralLoanApplicationId, page, size);
            if (HandleResponseError(response, logger, "Collateral", $"CollateralLoanApplicationId: '{collateralLoanApplicationId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-collaterals-with-type/{collateralsLoanApplicationId:int}/{collateralsCollateralTypeId:int}/{collateralTypesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCollateralsWithTypeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCollateralsWithTypeAsync(int collateralsLoanApplicationId, int collateralsCollateralTypeId, int collateralTypesId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetCollateralsWithTypeAsync(collateralsLoanApplicationId, collateralsCollateralTypeId, collateralTypesId, page, size);
            if (HandleResponseError(response, logger, "Collateral", $"CollateralsLoanApplicationId: '{collateralsLoanApplicationId}', CollateralsCollateralTypeId: '{collateralsCollateralTypeId}', CollateralTypesId: '{collateralTypesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("update-market-value/{collateralId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateMarketValueAsync(int collateralId, [FromBody] UpdateMarketValueRequestDto updateRequest)
        {
            var response = await service.UpdateMarketValueAsync(collateralId, updateRequest);
            if (HandleResponseError(response, logger, "Collateral", $"CollateralId: '{collateralId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}