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
    public class InsertAspNetUserCommand : IRequest<Response<AspNetUserDto>>
    {
        public AspNetUserDto request { get; set; }

        public InsertAspNetUserCommand(AspNetUserDto request)
        {
            this.request = request;
        }

        public class InsertAspNetUserHandler : IRequestHandler<InsertAspNetUserCommand, Response<AspNetUserDto>>
        {
            private readonly ILogger<InsertAspNetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public InsertAspNetUserHandler(ILogger<InsertAspNetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AspNetUserDto>> Handle(InsertAspNetUserCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}