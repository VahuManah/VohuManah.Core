using SharedKernel;

namespace Domain.BaseEntitys;

public static class BaseEntityItemErrors
{
    public static Error AlreadyCompleted(Guid BaseEntityItemId) => Error.Problem(
        "BaseEntityItems.AlreadyCompleted",
        $"The BaseEntity item with Id = '{BaseEntityItemId}' is already completed.");

    public static Error NotFound(Guid BaseEntityItemId) => Error.NotFound(
        "BaseEntityItems.NotFound",
        $"The to-do item with the Id = '{BaseEntityItemId}' was not found");
}
