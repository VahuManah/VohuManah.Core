using Application.Abstractions.Messaging;
using Application.BaseEntitys.Get;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.BaseEntitys;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("BaseEntitys", async (
            Guid userId,
            IQueryHandler<GetBaseEntitysQuery, List<BaseEntityResponse>> handler,
            CancellationToken cancellationToken) =>
        {
            var query = new GetBaseEntitysQuery(userId);

            Result<List<BaseEntityResponse>> result = await handler.Handle(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.BaseEntitys)
        .RequireAuthorization();
    }
}
