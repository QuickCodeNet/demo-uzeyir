using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.RepaymentSchedule;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.RepaymentSchedule;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Api.Controllers
{
    public partial class RepaymentSchedulesController : QuickCodeBaseApiController
    {
        private readonly IRepaymentScheduleService service;
        private readonly ILogger<RepaymentSchedulesController> logger;
        private readonly IServiceProvider serviceProvider;
        public RepaymentSchedulesController(IRepaymentScheduleService service, IServiceProvider serviceProvider, ILogger<RepaymentSchedulesController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RepaymentScheduleDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "RepaymentSchedule", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "RepaymentSchedule") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RepaymentScheduleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "RepaymentSchedule", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RepaymentScheduleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(RepaymentScheduleDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "RepaymentSchedule") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, RepaymentScheduleDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "RepaymentSchedule", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "RepaymentSchedule", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-loan-id/{repaymentScheduleLoanId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByLoanIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByLoanIdAsync(int repaymentScheduleLoanId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByLoanIdAsync(repaymentScheduleLoanId, page, size);
            if (HandleResponseError(response, logger, "RepaymentSchedule", $"RepaymentScheduleLoanId: '{repaymentScheduleLoanId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-upcoming-payments/{repaymentScheduleLoanId:int}/{repaymentScheduleStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetUpcomingPaymentsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetUpcomingPaymentsAsync(int repaymentScheduleLoanId, PaymentStatus repaymentScheduleStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetUpcomingPaymentsAsync(repaymentScheduleLoanId, repaymentScheduleStatus, page, size);
            if (HandleResponseError(response, logger, "RepaymentSchedule", $"RepaymentScheduleLoanId: '{repaymentScheduleLoanId}', RepaymentScheduleStatus: '{repaymentScheduleStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-overdue-payments/{repaymentScheduleLoanId:int}/{repaymentScheduleStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetOverduePaymentsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetOverduePaymentsAsync(int repaymentScheduleLoanId, PaymentStatus repaymentScheduleStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetOverduePaymentsAsync(repaymentScheduleLoanId, repaymentScheduleStatus, page, size);
            if (HandleResponseError(response, logger, "RepaymentSchedule", $"RepaymentScheduleLoanId: '{repaymentScheduleLoanId}', RepaymentScheduleStatus: '{repaymentScheduleStatus}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("mark-as-paid/{repaymentScheduleId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> MarkAsPaidAsync(int repaymentScheduleId, [FromBody] MarkAsPaidRequestDto updateRequest)
        {
            var response = await service.MarkAsPaidAsync(repaymentScheduleId, updateRequest);
            if (HandleResponseError(response, logger, "RepaymentSchedule", $"RepaymentScheduleId: '{repaymentScheduleId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}