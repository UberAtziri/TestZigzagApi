using System;
using FluentValidation;

namespace TestZigzagApi.Models.Validators
{
    public class AnimeUpdateRequestValidator : AbstractValidator<AnimeUpdateRequest>
    {
        public AnimeUpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .Must(x => Guid.TryParse(x, out _))
                .WithMessage("Id should be a valid GUID.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(500);

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.Rating)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.NumberOfEpisodes)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30);

            RuleFor(x => x.ReleaseDate)
                .Must(x => !x.Equals(default))
                .WithMessage("Release date can not be empty.");
        }
    }
}