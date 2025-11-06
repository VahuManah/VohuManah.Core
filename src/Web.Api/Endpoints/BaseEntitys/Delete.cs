using Application.Abstractions.Messaging;
using Application.BaseEntitys.Delete;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.BaseEntitys;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("BaseEntitys/{id:guid}", async (
            Guid id,
            ICommandHandler<DeleteBaseEntityCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteBaseEntityCommand(id);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.BaseEntitys)
        .RequireAuthorization();
    }
}
