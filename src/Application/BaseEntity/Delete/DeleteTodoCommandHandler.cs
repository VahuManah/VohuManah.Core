using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.BaseEntitys;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.BaseEntitys.Delete;

internal sealed class DeleteBaseEntityCommandHandler(IApplicationDbContext context, IUserContext userContext)
    : ICommandHandler<DeleteBaseEntityCommand>
{
    public async Task<Result> Handle(DeleteBaseEntityCommand command, CancellationToken cancellationToken)
    {
        BaseEntityItem? BaseEntityItem = await context.BaseEntityItems
            .SingleOrDefaultAsync(t => t.Id == command.BaseEntityItemId && t.UserId == userContext.UserId, cancellationToken);

        if (BaseEntityItem is null)
        {
            return Result.Failure(BaseEntityItemErrors.NotFound(command.BaseEntityItemId));
        }

        context.BaseEntityItems.Remove(BaseEntityItem);

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
