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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.AspNetRoleClaim;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.AspNetRoleClaim
{
    public class DeleteAspNetRoleClaimCommand : IRequest<Response<bool>>
    {
        public AspNetRoleClaimDto request { get; set; }

        public DeleteAspNetRoleClaimCommand(AspNetRoleClaimDto request)
        {
            this.request = request;
        }

        public class DeleteAspNetRoleClaimHandler : IRequestHandler<DeleteAspNetRoleClaimCommand, Response<bool>>
        {
            private readonly ILogger<DeleteAspNetRoleClaimHandler> _logger;
            private readonly IAspNetRoleClaimRepository _repository;
            public DeleteAspNetRoleClaimHandler(ILogger<DeleteAspNetRoleClaimHandler> logger, IAspNetRoleClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteAspNetRoleClaimCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}