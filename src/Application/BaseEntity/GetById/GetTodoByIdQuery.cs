using Application.Abstractions.Messaging;

namespace Application.BaseEntitys.GetById;

public sealed record GetBaseEntityByIdQuery(Guid BaseEntityItemId) : IQuery<BaseEntityResponse>;
