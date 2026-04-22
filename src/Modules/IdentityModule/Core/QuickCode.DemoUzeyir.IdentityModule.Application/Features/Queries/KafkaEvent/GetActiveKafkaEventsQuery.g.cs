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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.KafkaEvent;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.KafkaEvent
{
    public class GetActiveKafkaEventsQuery : IRequest<Response<List<GetActiveKafkaEventsResponseDto>>>
    {
        public GetActiveKafkaEventsQuery()
        {
        }

        public class GetActiveKafkaEventsHandler : IRequestHandler<GetActiveKafkaEventsQuery, Response<List<GetActiveKafkaEventsResponseDto>>>
        {
            private readonly ILogger<GetActiveKafkaEventsHandler> _logger;
            private readonly IKafkaEventRepository _repository;
            public GetActiveKafkaEventsHandler(ILogger<GetActiveKafkaEventsHandler> logger, IKafkaEventRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetActiveKafkaEventsResponseDto>>> Handle(GetActiveKafkaEventsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetActiveKafkaEventsAsync();
                return returnValue.ToResponse();
            }
        }
    }
}