using Application.Abstractions.Messaging;

namespace Application.BaseEntitys.Complete;

public sealed record CompleteBaseEntityCommand(Guid BaseEntityItemId) : ICommand;
