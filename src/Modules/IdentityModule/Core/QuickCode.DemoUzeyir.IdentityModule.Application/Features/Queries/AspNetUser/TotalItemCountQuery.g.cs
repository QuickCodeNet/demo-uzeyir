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
    public class TotalCountAspNetUserQuery : IRequest<Response<int>>
    {
        public TotalCountAspNetUserQuery()
        {
        }

        public class TotalCountAspNetUserHandler : IRequestHandler<TotalCountAspNetUserQuery, Response<int>>
        {
            private readonly ILogger<TotalCountAspNetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public TotalCountAspNetUserHandler(ILogger<TotalCountAspNetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountAspNetUserQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}