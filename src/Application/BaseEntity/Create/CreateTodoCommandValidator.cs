using FluentValidation;

namespace Application.BaseEntitys.Create;

public class CreateBaseEntityCommandValidator : AbstractValidator<CreateBaseEntityCommand>
{
    public CreateBaseEntityCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Priority).IsInEnum();
        RuleFor(c => c.Description).NotEmpty().MaximumLength(255);
        RuleFor(c => c.DueDate).GreaterThanOrEqualTo(DateTime.Today).When(x => x.DueDate.HasValue);
    }
}
