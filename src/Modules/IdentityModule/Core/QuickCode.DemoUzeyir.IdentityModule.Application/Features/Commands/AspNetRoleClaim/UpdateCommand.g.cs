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
    public class UpdateAspNetRoleClaimCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
        public AspNetRoleClaimDto request { get; set; }

        public UpdateAspNetRoleClaimCommand(int id, AspNetRoleClaimDto request)
        {
            this.request = request;
            this.Id = id;
        }

        public class UpdateAspNetRoleClaimHandler : IRequestHandler<UpdateAspNetRoleClaimCommand, Response<bool>>
        {
            private readonly ILogger<UpdateAspNetRoleClaimHandler> _logger;
            private readonly IAspNetRoleClaimRepository _repository;
            public UpdateAspNetRoleClaimHandler(ILogger<UpdateAspNetRoleClaimHandler> logger, IAspNetRoleClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateAspNetRoleClaimCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Id);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}