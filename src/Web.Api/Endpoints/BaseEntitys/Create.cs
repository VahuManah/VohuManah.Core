using Application.Abstractions.Messaging;
using Application.BaseEntitys.Create;
using Domain.BaseEntitys;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.BaseEntitys;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public List<string> Labels { get; set; } = [];
        public int Priority { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("BaseEntitys", async (
            Request request,
            ICommandHandler<CreateBaseEntityCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateBaseEntityCommand
            {
                UserId = request.UserId,
                Description = request.Description,
                DueDate = request.DueDate,
                Labels = request.Labels,
                Priority = (Priority)request.Priority
            };

            Result<Guid> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.BaseEntitys)
        .RequireAuthorization();
    }
}
