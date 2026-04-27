using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.IdentificationDocument;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.IdentificationDocument
{
    public partial class IdentificationDocumentService : IIdentificationDocumentService
    {
        private readonly ILogger<IdentificationDocumentService> _logger;
        private readonly IIdentificationDocumentRepository _repository;
        public IdentificationDocumentService(ILogger<IdentificationDocumentService> logger, IIdentificationDocumentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<IdentificationDocumentDto>> InsertAsync(IdentificationDocumentDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(IdentificationDocumentDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, IdentificationDocumentDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<IdentificationDocumentDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<IdentificationDocumentDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int identificationDocumentCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(identificationDocumentCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetDocumentsWithTypeResponseDto>>> GetDocumentsWithTypeAsync(int identificationDocumentsCustomerId, int identificationDocumentsDocumentTypeId, int documentTypesId, int? page, int? size)
        {
            var returnValue = await _repository.GetDocumentsWithTypeAsync(identificationDocumentsCustomerId, identificationDocumentsDocumentTypeId, documentTypesId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetExpiringSoonResponseDto>>> GetExpiringSoonAsync(DocumentStatus identificationDocumentStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetExpiringSoonAsync(identificationDocumentStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> VerifyDocumentAsync(int identificationDocumentId, VerifyDocumentRequestDto updateRequest)
        {
            var returnValue = await _repository.VerifyDocumentAsync(identificationDocumentId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RejectDocumentAsync(int identificationDocumentId, RejectDocumentRequestDto updateRequest)
        {
            var returnValue = await _repository.RejectDocumentAsync(identificationDocumentId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkAsExpiredAsync(int identificationDocumentId, MarkAsExpiredRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkAsExpiredAsync(identificationDocumentId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}