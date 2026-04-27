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
    public class IdentityUserByIdQuery : IRequest<Response<List<IdentityUserByIdResponseDto>>>
    {
        public string AspNetUserId { get; set; }

        public IdentityUserByIdQuery(string aspNetUserId)
        {
            this.AspNetUserId = aspNetUserId;
        }

        public class IdentityUserByIdHandler : IRequestHandler<IdentityUserByIdQuery, Response<List<IdentityUserByIdResponseDto>>>
        {
            private readonly ILogger<IdentityUserByIdHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public IdentityUserByIdHandler(ILogger<IdentityUserByIdHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<IdentityUserByIdResponseDto>>> Handle(IdentityUserByIdQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.IdentityUserByIdAsync(request.AspNetUserId);
                return returnValue.ToResponse();
            }
        }
    }
}