using Application.Abstractions.Messaging;

namespace Application.BaseEntitys.Delete;

public sealed record DeleteBaseEntityCommand(Guid BaseEntityItemId) : ICommand;
