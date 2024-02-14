namespace HeartifyDating.Infrastructure.Constants
{
    /// <summary>
    /// Validation Constants
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Maximal First and Last Name length
        /// </summary>
        public const int NamesMaxLength = 50;

        /// <summary>
        /// Minimal First and Last Name length
        /// </summary>
        public const int NamesMinLength = 3;

        /// <summary>
        /// Maximal First Name length
        /// </summary>
        public const int MaxAge = 99;

        /// <summary>
        /// Minimal Age of Person
        /// </summary>
        public const int MinAge = 18;

        /// <summary>
        /// Maximal Gender length
        /// </summary>
        public const int GenderMaxLength = 40;

        /// <summary>
        /// Minimal Gender length
        /// </summary>
        public const int GenderMinLength = 10;

        /// <summary>
        /// Maximal Relationship Type length
        /// </summary>
        public const int RelationshipTypeMaxLength = 30;

        /// <summary>
        /// Minimal Relationship Type length
        /// </summary>
        public const int RelationshipTypeMinLength = 10;

        /// <summary>
        /// Maximal Description length
        /// </summary>
        public const int DescriptionMaxLength = 150;

        /// <summary>
        /// Minimal Description length
        /// </summary>
        public const int DescriptionMinLength = 2;

        /// <summary>
        /// Require Error Message Text
        /// </summary>
        public const string RequiredErrorMessage = "The {0} field is required!";

        /// <summary>
        /// Input is not long enough or is too long
        /// </summary>
        public const string StringLengthErrorMessage = "The {0} field must be between {2} and {1} characters long!";

        /// <summary>
        /// Age is not in the permitted range
        /// </summary>
        public const string AgeIsntInRangeErrorMessage = "{0} must be in the range {2} - {1}";
    }
}
