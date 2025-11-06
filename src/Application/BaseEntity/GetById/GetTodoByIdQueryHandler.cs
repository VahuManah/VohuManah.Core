using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.BaseEntitys;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.BaseEntitys.GetById;

internal sealed class GetBaseEntityByIdQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetBaseEntityByIdQuery, BaseEntityResponse>
{
    public async Task<Result<BaseEntityResponse>> Handle(GetBaseEntityByIdQuery query, CancellationToken cancellationToken)
    {
        BaseEntityResponse? BaseEntity = await context.BaseEntityItems
            .Where(BaseEntityItem => BaseEntityItem.Id == query.BaseEntityItemId && BaseEntityItem.UserId == userContext.UserId)
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
            .SingleOrDefaultAsync(cancellationToken);

        if (BaseEntity is null)
        {
            return Result.Failure<BaseEntityResponse>(BaseEntityItemErrors.NotFound(query.BaseEntityItemId));
        }

        return BaseEntity;
    }
}
