using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.BaseEntitys;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.BaseEntitys.Complete;

internal sealed class CompleteBaseEntityCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContext userContext)
    : ICommandHandler<CompleteBaseEntityCommand>
{
    public async Task<Result> Handle(CompleteBaseEntityCommand command, CancellationToken cancellationToken)
    {
        BaseEntityItem? BaseEntityItem = await context.BaseEntityItems
            .SingleOrDefaultAsync(t => t.Id == command.BaseEntityItemId && t.UserId == userContext.UserId, cancellationToken);

        if (BaseEntityItem is null)
        {
            return Result.Failure(BaseEntityItemErrors.NotFound(command.BaseEntityItemId));
        }

        if (BaseEntityItem.IsCompleted)
        {
            return Result.Failure(BaseEntityItemErrors.AlreadyCompleted(command.BaseEntityItemId));
        }

        BaseEntityItem.IsCompleted = true;
        BaseEntityItem.CompletedAt = dateTimeProvider.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
