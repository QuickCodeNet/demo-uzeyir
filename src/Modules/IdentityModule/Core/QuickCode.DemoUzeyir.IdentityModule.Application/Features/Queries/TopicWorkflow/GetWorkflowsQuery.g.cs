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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.TopicWorkflow;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.TopicWorkflow
{
    public class GetWorkflowsQuery : IRequest<Response<List<GetWorkflowsResponseDto>>>
    {
        public string TopicWorkflowKafkaEventsTopicName { get; set; }

        public GetWorkflowsQuery(string topicWorkflowKafkaEventsTopicName)
        {
            this.TopicWorkflowKafkaEventsTopicName = topicWorkflowKafkaEventsTopicName;
        }

        public class GetWorkflowsHandler : IRequestHandler<GetWorkflowsQuery, Response<List<GetWorkflowsResponseDto>>>
        {
            private readonly ILogger<GetWorkflowsHandler> _logger;
            private readonly ITopicWorkflowRepository _repository;
            public GetWorkflowsHandler(ILogger<GetWorkflowsHandler> logger, ITopicWorkflowRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetWorkflowsResponseDto>>> Handle(GetWorkflowsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetWorkflowsAsync(request.TopicWorkflowKafkaEventsTopicName);
                return returnValue.ToResponse();
            }
        }
    }
}