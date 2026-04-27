using System;
using System.Linq;
using QuickCode.DemoUzeyir.Common.Mediator;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Entities;
using QuickCode.DemoUzeyir.IdentityModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.AspNetUser;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.AspNetUser
{
    public class IdentityUserByNormalizedUsernameQuery : IRequest<Response<List<IdentityUserByNormalizedUsernameResponseDto>>>
    {
        public string? AspNetUserNormalizedUserName { get; set; }

        public IdentityUserByNormalizedUsernameQuery(string? aspNetUserNormalizedUserName)
        {
            this.AspNetUserNormalizedUserName = aspNetUserNormalizedUserName;
        }

        public class IdentityUserByNormalizedUsernameHandler : IRequestHandler<IdentityUserByNormalizedUsernameQuery, Response<List<IdentityUserByNormalizedUsernameResponseDto>>>
        {
            private readonly ILogger<IdentityUserByNormalizedUsernameHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public IdentityUserByNormalizedUsernameHandler(ILogger<IdentityUserByNormalizedUsernameHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<IdentityUserByNormalizedUsernameResponseDto>>> Handle(IdentityUserByNormalizedUsernameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.IdentityUserByNormalizedUsernameAsync(request.AspNetUserNormalizedUserName);
                return returnValue.ToResponse();
            }
        }
    }
}