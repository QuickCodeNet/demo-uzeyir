using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.DocumentType;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.DocumentType
{
    public partial interface IDocumentTypeService
    {
        Task<Response<DocumentTypeDto>> InsertAsync(DocumentTypeDto request);
        Task<Response<bool>> DeleteAsync(DocumentTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, DocumentTypeDto request);
        Task<Response<List<DocumentTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<DocumentTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool documentTypeIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string documentTypeCode);
        Task<Response<int>> DeactivateAsync(int documentTypeId, DeactivateRequestDto updateRequest);
    }
}