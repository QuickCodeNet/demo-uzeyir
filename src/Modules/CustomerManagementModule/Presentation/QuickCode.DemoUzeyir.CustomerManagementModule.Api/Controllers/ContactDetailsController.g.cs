using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.ContactDetail;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.ContactDetail;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Api.Controllers
{
    public partial class ContactDetailsController : QuickCodeBaseApiController
    {
        private readonly IContactDetailService service;
        private readonly ILogger<ContactDetailsController> logger;
        private readonly IServiceProvider serviceProvider;
        public ContactDetailsController(IContactDetailService service, IServiceProvider serviceProvider, ILogger<ContactDetailsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContactDetailDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "ContactDetail", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "ContactDetail") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactDetailDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "ContactDetail", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ContactDetailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(ContactDetailDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "ContactDetail") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, ContactDetailDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "ContactDetail", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "ContactDetail", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-id/{contactDetailCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByCustomerIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerIdAsync(int contactDetailCustomerId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByCustomerIdAsync(contactDetailCustomerId, page, size);
            if (HandleResponseError(response, logger, "ContactDetail", $"ContactDetailCustomerId: '{contactDetailCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-unverified-contacts/{contactDetailIsVerified:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetUnverifiedContactsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetUnverifiedContactsAsync(bool contactDetailIsVerified, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetUnverifiedContactsAsync(contactDetailIsVerified, page, size);
            if (HandleResponseError(response, logger, "ContactDetail", $"ContactDetailIsVerified: '{contactDetailIsVerified}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("mark-as-verified/{contactDetailId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> MarkAsVerifiedAsync(int contactDetailId, [FromBody] MarkAsVerifiedRequestDto updateRequest)
        {
            var response = await service.MarkAsVerifiedAsync(contactDetailId, updateRequest);
            if (HandleResponseError(response, logger, "ContactDetail", $"ContactDetailId: '{contactDetailId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpDelete("remove-contact/{contactDetailId:int}/{contactDetailCustomerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RemoveContactAsync(int contactDetailId, int contactDetailCustomerId)
        {
            var response = await service.RemoveContactAsync(contactDetailId, contactDetailCustomerId);
            if (HandleResponseError(response, logger, "ContactDetail", $"ContactDetailId: '{contactDetailId}', ContactDetailCustomerId: '{contactDetailCustomerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}