using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.Address;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.Address;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Api.Controllers
{
    public partial class AddressesController : QuickCodeBaseApiController
    {
        private readonly IAddressService service;
        private readonly ILogger<AddressesController> logger;
        private readonly IServiceProvider serviceProvider;
        public AddressesController(IAddressService service, IServiceProvider serviceProvider, ILogger<AddressesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AddressDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Address", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Address") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Address", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(AddressDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Address") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, AddressDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Address", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Address", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-id/{addressCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerIdAsync(int addressCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerIdAsync(addressCustomerId, page, size);
            if (HandleResponseError(response, logger, "Address", $"AddressCustomerId: '{addressCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-primary-by-customer-id/{addressCustomerId:int}/{addressIsPrimary:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPrimaryByCustomerIdResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPrimaryByCustomerIdAsync(int addressCustomerId, bool addressIsPrimary)
        {
            var response = await service.GetPrimaryByCustomerIdAsync(addressCustomerId, addressIsPrimary);
            if (HandleResponseError(response, logger, "Address", $"AddressCustomerId: '{addressCustomerId}', AddressIsPrimary: '{addressIsPrimary}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("set-as-primary/{addressId:int}/{addressCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SetAsPrimaryAsync(int addressId, int addressCustomerId, [FromBody] SetAsPrimaryRequestDto updateRequest)
        {
            var response = await service.SetAsPrimaryAsync(addressId, addressCustomerId, updateRequest);
            if (HandleResponseError(response, logger, "Address", $"AddressId: '{addressId}', AddressCustomerId: '{addressCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("unset-primary/{addressCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UnsetPrimaryAsync(int addressCustomerId, [FromBody] UnsetPrimaryRequestDto updateRequest)
        {
            var response = await service.UnsetPrimaryAsync(addressCustomerId, updateRequest);
            if (HandleResponseError(response, logger, "Address", $"AddressCustomerId: '{addressCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("remove-address/{addressId:int}/{addressCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RemoveAddressAsync(int addressId, int addressCustomerId)
        {
            var response = await service.RemoveAddressAsync(addressId, addressCustomerId);
            if (HandleResponseError(response, logger, "Address", $"AddressId: '{addressId}', AddressCustomerId: '{addressCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}