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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.AspNetUserToken;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.AspNetUserToken
{
    public class InsertAspNetUserTokenCommand : IRequest<Response<AspNetUserTokenDto>>
    {
        public AspNetUserTokenDto request { get; set; }

        public InsertAspNetUserTokenCommand(AspNetUserTokenDto request)
        {
            this.request = request;
        }

        public class InsertAspNetUserTokenHandler : IRequestHandler<InsertAspNetUserTokenCommand, Response<AspNetUserTokenDto>>
        {
            private readonly ILogger<InsertAspNetUserTokenHandler> _logger;
            private readonly IAspNetUserTokenRepository _repository;
            public InsertAspNetUserTokenHandler(ILogger<InsertAspNetUserTokenHandler> logger, IAspNetUserTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserTokenDto>> Handle(InsertAspNetUserTokenCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}