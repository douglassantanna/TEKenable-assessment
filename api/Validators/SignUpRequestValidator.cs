using api.Models;
using FluentValidation;

namespace api.Validators;
public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
{
    public SignUpRequestValidator()
    {
        RuleFor(x => x.ReasonForSignUp)
            .NotNull().WithMessage("Field Reason for sign up is required!")
            .Length(0, 255).WithMessage("Reason for sign up must be less than 255 characters!");
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Please, insert a valid email!")
            .MaximumLength(255).WithMessage("Email must be less than 255 characters!");
        RuleFor(x => x.HowHeardAboutUs)
            .IsInEnum().WithMessage("Field How heard about us is invalid!");
    }
}