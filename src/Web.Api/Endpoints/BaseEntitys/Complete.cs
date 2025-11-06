using Application.Abstractions.Messaging;
using Application.BaseEntitys.Complete;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.BaseEntitys;

internal sealed class Complete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("BaseEntitys/{id:guid}/complete", async (
            Guid id,
            ICommandHandler<CompleteBaseEntityCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new CompleteBaseEntityCommand(id);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.BaseEntitys)
        .RequireAuthorization();
    }
}
