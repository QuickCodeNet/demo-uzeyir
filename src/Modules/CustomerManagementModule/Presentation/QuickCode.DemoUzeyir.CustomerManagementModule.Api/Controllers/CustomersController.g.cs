using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.Customer;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.Customer;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Api.Controllers
{
    public partial class CustomersController : QuickCodeBaseApiController
    {
        private readonly ICustomerService service;
        private readonly ILogger<CustomersController> logger;
        private readonly IServiceProvider serviceProvider;
        public CustomersController(ICustomerService service, IServiceProvider serviceProvider, ILogger<CustomersController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Customer", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Customer") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Customer", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(CustomerDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Customer") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, CustomerDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Customer", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Customer", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-customer-number/{customerCustomerNumber:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByCustomerNumberResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByCustomerNumberAsync(Guid customerCustomerNumber)
        {
            var response = await service.GetByCustomerNumberAsync(customerCustomerNumber);
            if (HandleResponseError(response, logger, "Customer", $"CustomerCustomerNumber: '{customerCustomerNumber}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("search-by-name/{customerLastName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SearchByNameResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SearchByNameAsync(string customerLastName, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.SearchByNameAsync(customerLastName, page, size);
            if (HandleResponseError(response, logger, "Customer", $"CustomerLastName: '{customerLastName}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active-customers/{customerStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetActiveCustomersResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveCustomersAsync(CustomerStatus customerStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetActiveCustomersAsync(customerStatus, page, size);
            if (HandleResponseError(response, logger, "Customer", $"CustomerStatus: '{customerStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-customers-by-type/{customersCustomerTypeId:int}/{customerTypesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCustomersByTypeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCustomersByTypeAsync(int customersCustomerTypeId, int customerTypesId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetCustomersByTypeAsync(customersCustomerTypeId, customerTypesId, page, size);
            if (HandleResponseError(response, logger, "Customer", $"CustomersCustomerTypeId: '{customersCustomerTypeId}', CustomerTypesId: '{customerTypesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-recently-joined")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetRecentlyJoinedResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetRecentlyJoinedAsync(int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetRecentlyJoinedAsync(page, size);
            if (HandleResponseError(response, logger, "Customer", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-active-count-by-type/{customersCustomerTypeId:int}/{customersStatus}/{customerTypesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetActiveCountByTypeAsync(int customersCustomerTypeId, CustomerStatus customersStatus, int customerTypesId)
        {
            var response = await service.GetActiveCountByTypeAsync(customersCustomerTypeId, customersStatus, customerTypesId);
            if (HandleResponseError(response, logger, "Customer", $"CustomersCustomerTypeId: '{customersCustomerTypeId}', CustomersStatus: '{customersStatus}', CustomerTypesId: '{customerTypesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("activate-customer/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ActivateCustomerAsync(int customerId, [FromBody] ActivateCustomerRequestDto updateRequest)
        {
            var response = await service.ActivateCustomerAsync(customerId, updateRequest);
            if (HandleResponseError(response, logger, "Customer", $"CustomerId: '{customerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("suspend-customer/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SuspendCustomerAsync(int customerId, [FromBody] SuspendCustomerRequestDto updateRequest)
        {
            var response = await service.SuspendCustomerAsync(customerId, updateRequest);
            if (HandleResponseError(response, logger, "Customer", $"CustomerId: '{customerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("close-customer/{customerId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CloseCustomerAsync(int customerId, [FromBody] CloseCustomerRequestDto updateRequest)
        {
            var response = await service.CloseCustomerAsync(customerId, updateRequest);
            if (HandleResponseError(response, logger, "Customer", $"CustomerId: '{customerId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}