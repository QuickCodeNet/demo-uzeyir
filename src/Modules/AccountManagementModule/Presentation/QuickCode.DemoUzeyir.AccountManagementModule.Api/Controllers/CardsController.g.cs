using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCode.DemoUzeyir.Common.Controllers;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.Card;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.Card;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Api.Controllers
{
    public partial class CardsController : QuickCodeBaseApiController
    {
        private readonly ICardService service;
        private readonly ILogger<CardsController> logger;
        private readonly IServiceProvider serviceProvider;
        public CardsController(ICardService service, IServiceProvider serviceProvider, ILogger<CardsController> logger)
        {
            this.service = service;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CardDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ListAsync([FromQuery] int? page, int? size)
        {
            if (ValidatePagination(page, size) is {} error)
                return error;
            var response = await service.ListAsync(page, size);
            if (HandleResponseError(response, logger, "Card", "List") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> CountAsync()
        {
            var response = await service.TotalItemCountAsync();
            if (HandleResponseError(response, logger, "Card") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CardDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var response = await service.GetItemAsync(id);
            if (HandleResponseError(response, logger, "Card", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CardDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> InsertAsync(CardDto model)
        {
            var response = await service.InsertAsync(model);
            if (HandleResponseError(response, logger, "Card") is {} responseError)
                return responseError;
            return CreatedAtRoute(new { id = response.Value.Id }, response.Value);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(int id, CardDto model)
        {
            if (!(model.Id == id))
            {
                return BadRequest($"Id: '{id}' must be equal to model.Id: '{model.Id}'");
            }

            var response = await service.UpdateAsync(id, model);
            if (HandleResponseError(response, logger, "Card", $"Id: '{id}'") is {} responseError)
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
            if (HandleResponseError(response, logger, "Card", $"Id: '{id}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-by-account-id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetByAccountIdResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetByAccountIdAsync(int cardAccountId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetByAccountIdAsync(cardAccountId, page, size);
            if (HandleResponseError(response, logger, "Card", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-cards-with-type/{cardTypesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetCardsWithTypeResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetCardsWithTypeAsync(int cardTypesId, int cardsAccountId, int cardsCardTypeId, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetCardsWithTypeAsync(cardTypesId, cardsAccountId, cardsCardTypeId, page, size);
            if (HandleResponseError(response, logger, "Card", $"CardTypesId: '{cardTypesId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpGet("get-expired-cards")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetExpiredCardsResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetExpiredCardsAsync(CardStatus cardStatus, int? page, int? size)
        {
            if (page < 1)
            {
                var pageNumberError = $"Page Number must be greater than 1";
                logger.LogWarning($"List Error: '{pageNumberError}''");
                return NotFound(pageNumberError);
            }

            var response = await service.GetExpiredCardsAsync(cardStatus, page, size);
            if (HandleResponseError(response, logger, "Card", $"") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("activate-card/{cardId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ActivateCardAsync(int cardId, [FromBody] ActivateCardRequestDto updateRequest)
        {
            var response = await service.ActivateCardAsync(cardId, updateRequest);
            if (HandleResponseError(response, logger, "Card", $"CardId: '{cardId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("block-card/{cardId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> BlockCardAsync(int cardId, [FromBody] BlockCardRequestDto updateRequest)
        {
            var response = await service.BlockCardAsync(cardId, updateRequest);
            if (HandleResponseError(response, logger, "Card", $"CardId: '{cardId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }

        [HttpPatch("report-lost-or-stolen/{cardId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> ReportLostOrStolenAsync(int cardId, [FromBody] ReportLostOrStolenRequestDto updateRequest)
        {
            var response = await service.ReportLostOrStolenAsync(cardId, updateRequest);
            if (HandleResponseError(response, logger, "Card", $"CardId: '{cardId}'") is {} responseError)
                return responseError;
            return Ok(response.Value);
        }
    }
}