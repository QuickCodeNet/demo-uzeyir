using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.Beneficiary;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.Beneficiary
{
    public partial interface IBeneficiaryService
    {
        Task<Response<BeneficiaryDto>> InsertAsync(BeneficiaryDto request);
        Task<Response<bool>> DeleteAsync(BeneficiaryDto request);
        Task<Response<bool>> UpdateAsync(int id, BeneficiaryDto request);
        Task<Response<List<BeneficiaryDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<BeneficiaryDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int beneficiaryCustomerId, bool beneficiaryIsActive, int? page, int? size);
        Task<Response<List<SearchByNicknameResponseDto>>> SearchByNicknameAsync(int beneficiaryCustomerId, string beneficiaryNickname, int? page, int? size);
        Task<Response<int>> DeactivateAsync(int beneficiaryId, DeactivateRequestDto updateRequest);
    }
}