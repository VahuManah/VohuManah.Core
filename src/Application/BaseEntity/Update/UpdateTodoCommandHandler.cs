using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.BaseEntitys;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.BaseEntitys.Update;

internal sealed class UpdateBaseEntityCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<UpdateBaseEntityCommand>
{
    public async Task<Result> Handle(UpdateBaseEntityCommand command, CancellationToken cancellationToken)
    {
        BaseEntityItem? BaseEntityItem = await context.BaseEntityItems
            .SingleOrDefaultAsync(t => t.Id == command.BaseEntityItemId, cancellationToken);

        if (BaseEntityItem is null)
        {
            return Result.Failure(BaseEntityItemErrors.NotFound(command.BaseEntityItemId));
        }

        BaseEntityItem.Description = command.Description;

        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}
