using FluentValidation;
using TestZigzagApi.Models.Validators.Constants;

namespace TestZigzagApi.Models.Validators
{
    public class AnimeCreateRequestValidator : AbstractValidator<AnimeCreateRequest>
    {
        public AnimeCreateRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(AnimeValidationConstants.MaximumDescriptionLength);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(AnimeValidationConstants.MaximumNameLength);

            RuleFor(x => x.Rating)
                .GreaterThanOrEqualTo(AnimeValidationConstants.RatingGreaterOrEqual);

            RuleFor(x => x.NumberOfEpisodes)
                .GreaterThanOrEqualTo(AnimeValidationConstants.NumberOfEpisodesGreaterOrEqual);

            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .MaximumLength(AnimeValidationConstants.MaximumCategoryLength);

            RuleFor(x => x.ReleaseDate)
                .Must(x => !x.Equals(default))
                .WithMessage(AnimeValidationConstants.EmptyReleaseDateMessage);
        }
    }
}