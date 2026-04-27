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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.AuditLog;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.AuditLog
{
    public class InsertAuditLogCommand : IRequest<Response<AuditLogDto>>
    {
        public AuditLogDto request { get; set; }

        public InsertAuditLogCommand(AuditLogDto request)
        {
            this.request = request;
        }

        public class InsertAuditLogHandler : IRequestHandler<InsertAuditLogCommand, Response<AuditLogDto>>
        {
            private readonly ILogger<InsertAuditLogHandler> _logger;
            private readonly IAuditLogRepository _repository;
            public InsertAuditLogHandler(ILogger<InsertAuditLogHandler> logger, IAuditLogRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AuditLogDto>> Handle(InsertAuditLogCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}