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
    public class GetTopicWorkflowsQuery : IRequest<Response<List<GetTopicWorkflowsResponseDto>>>
    {
        public string KafkaEventsTopicName { get; set; }
        public HttpMethodType ApiMethodDefinitionsHttpMethod { get; set; }

        public GetTopicWorkflowsQuery(string kafkaEventsTopicName, HttpMethodType apiMethodDefinitionsHttpMethod)
        {
            this.KafkaEventsTopicName = kafkaEventsTopicName;
            this.ApiMethodDefinitionsHttpMethod = apiMethodDefinitionsHttpMethod;
        }

        public class GetTopicWorkflowsHandler : IRequestHandler<GetTopicWorkflowsQuery, Response<List<GetTopicWorkflowsResponseDto>>>
        {
            private readonly ILogger<GetTopicWorkflowsHandler> _logger;
            private readonly ITopicWorkflowRepository _repository;
            public GetTopicWorkflowsHandler(ILogger<GetTopicWorkflowsHandler> logger, ITopicWorkflowRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetTopicWorkflowsResponseDto>>> Handle(GetTopicWorkflowsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetTopicWorkflowsAsync(request.KafkaEventsTopicName, request.ApiMethodDefinitionsHttpMethod);
                return returnValue.ToResponse();
            }
        }
    }
}