using FluentValidation;

namespace Application.BaseEntitys.Delete;

internal sealed class DeleteBaseEntityCommandValidator : AbstractValidator<DeleteBaseEntityCommand>
{
    public DeleteBaseEntityCommandValidator()
    {
        RuleFor(c => c.BaseEntityItemId).NotEmpty();
    }
}
