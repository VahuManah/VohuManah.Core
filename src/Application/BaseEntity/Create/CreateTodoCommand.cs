using Application.Abstractions.Messaging;
using Domain.BaseEntitys;

namespace Application.BaseEntitys.Create;

public sealed class CreateBaseEntityCommand : ICommand<Guid>
{
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public List<string> Labels { get; set; } = [];
    public Priority Priority { get; set; }
}
