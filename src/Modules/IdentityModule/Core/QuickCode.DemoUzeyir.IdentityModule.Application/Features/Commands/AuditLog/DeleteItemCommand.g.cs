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
    public class DeleteItemAuditLogCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }

        public DeleteItemAuditLogCommand(Guid id)
        {
            this.Id = id;
        }

        public class DeleteItemAuditLogHandler : IRequestHandler<DeleteItemAuditLogCommand, Response<bool>>
        {
            private readonly ILogger<DeleteItemAuditLogHandler> _logger;
            private readonly IAuditLogRepository _repository;
            public DeleteItemAuditLogHandler(ILogger<DeleteItemAuditLogHandler> logger, IAuditLogRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteItemAuditLogCommand request, CancellationToken cancellationToken)
            {
                var deleteItem = await _repository.GetByPkAsync(request.Id);
                if (deleteItem.Code == 404)
                    return Response<bool>.NotFound();
                var returnValue = await _repository.DeleteAsync(deleteItem.Value);
                return returnValue.ToResponse();
            }
        }
    }
}