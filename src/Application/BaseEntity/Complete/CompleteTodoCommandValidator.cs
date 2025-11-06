using FluentValidation;

namespace Application.BaseEntitys.Complete;

internal sealed class CompleteBaseEntityCommandValidator : AbstractValidator<CompleteBaseEntityCommand>
{
    public CompleteBaseEntityCommandValidator()
    {
        RuleFor(c => c.BaseEntityItemId).NotEmpty();
    }
}
