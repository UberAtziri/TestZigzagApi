namespace TestZigzagApi.Models.Validators.Constants
{
    public static class AnimeValidationConstants
    {
        public const int MaximumDescriptionLength = 500;

        public const int MaximumNameLength = 50;

        public const int MaximumCategoryLength = 30;

        public const int RatingGreaterOrEqual = 0;

        public const int NumberOfEpisodesGreaterOrEqual = 0;

        public const string EmptyReleaseDateMessage = "Release date can not be empty.";

        public const string InvalidGuidIdMessage = "Id should be a valid GUID.";
    }
}