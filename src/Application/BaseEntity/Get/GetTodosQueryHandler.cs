using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.BaseEntitys.Get;

internal sealed class GetBaseEntitysQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetBaseEntitysQuery, List<BaseEntityResponse>>
{
    public async Task<Result<List<BaseEntityResponse>>> Handle(GetBaseEntitysQuery query, CancellationToken cancellationToken)
    {
        if (query.UserId != userContext.UserId)
        {
            return Result.Failure<List<BaseEntityResponse>>(UserErrors.Unauthorized());
        }

        List<BaseEntityResponse> BaseEntitys = await context.BaseEntityItems
            .Where(BaseEntityItem => BaseEntityItem.UserId == query.UserId)
            .Select(BaseEntityItem => new BaseEntityResponse
            {
                Id = BaseEntityItem.Id,
                UserId = BaseEntityItem.UserId,
                Description = BaseEntityItem.Description,
                DueDate = BaseEntityItem.DueDate,
                Labels = BaseEntityItem.Labels,
                IsCompleted = BaseEntityItem.IsCompleted,
                CreatedAt = BaseEntityItem.CreatedAt,
                CompletedAt = BaseEntityItem.CompletedAt
            })
            .ToListAsync(cancellationToken);

        return BaseEntitys;
    }
}
