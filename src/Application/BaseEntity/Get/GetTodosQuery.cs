using Application.Abstractions.Messaging;

namespace Application.BaseEntitys.Get;

public sealed record GetBaseEntitysQuery(Guid UserId) : IQuery<List<BaseEntityResponse>>;
