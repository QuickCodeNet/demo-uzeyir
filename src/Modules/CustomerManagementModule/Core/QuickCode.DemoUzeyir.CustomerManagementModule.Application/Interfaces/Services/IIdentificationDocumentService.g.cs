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
    public partial interface IIdentificationDocumentService
    {
        Task<Response<IdentificationDocumentDto>> InsertAsync(IdentificationDocumentDto request);
        Task<Response<bool>> DeleteAsync(IdentificationDocumentDto request);
        Task<Response<bool>> UpdateAsync(int id, IdentificationDocumentDto request);
        Task<Response<List<IdentificationDocumentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<IdentificationDocumentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int identificationDocumentCustomerId, int? page, int? size);
        Task<Response<List<GetDocumentsWithTypeResponseDto>>> GetDocumentsWithTypeAsync(int identificationDocumentsCustomerId, int identificationDocumentsDocumentTypeId, int documentTypesId, int? page, int? size);
        Task<Response<List<GetExpiringSoonResponseDto>>> GetExpiringSoonAsync(DocumentStatus identificationDocumentStatus, int? page, int? size);
        Task<Response<int>> VerifyDocumentAsync(int identificationDocumentId, VerifyDocumentRequestDto updateRequest);
        Task<Response<int>> RejectDocumentAsync(int identificationDocumentId, RejectDocumentRequestDto updateRequest);
        Task<Response<int>> MarkAsExpiredAsync(int identificationDocumentId, MarkAsExpiredRequestDto updateRequest);
    }
}