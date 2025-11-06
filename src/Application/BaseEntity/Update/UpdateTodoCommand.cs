using Application.Abstractions.Messaging;

namespace Application.BaseEntitys.Update;

public sealed record UpdateBaseEntityCommand(
    Guid BaseEntityItemId,
    string Description) : ICommand;
