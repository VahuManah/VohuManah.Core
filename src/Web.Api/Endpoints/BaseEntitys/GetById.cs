using Application.Abstractions.Messaging;
using Application.BaseEntitys.GetById;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.BaseEntitys;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("BaseEntitys/{id:guid}", async (
            Guid id,
            IQueryHandler<GetBaseEntityByIdQuery, BaseEntityResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new GetBaseEntityByIdQuery(id);

            Result<BaseEntityResponse> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.BaseEntitys)
        .RequireAuthorization();
    }
}
