namespace Heartify.Infrastructure.Constants
{
    /// <summary>
    /// Validation Constants
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Format of Date in App
        /// </summary>
        public const string DateFormat = "dd-MM-yyyy";

        /// <summary>
        /// Maximal First and Last Name Length
        /// </summary>
        public const int NamesMaxLength = 50;

        /// <summary>
        /// Minimal First and Last Name Length
        /// </summary>
        public const int NamesMinLength = 3;

        /// <summary>
        /// Maximal First Name Length
        /// </summary>
        public const int MaxAge = 99;

        /// <summary>
        /// Minimal Age of Person
        /// </summary>
        public const int MinAge = 18;

        /// <summary>
        /// Maximal Gender Length
        /// </summary>
        public const int GenderMaxLength = 40;

        /// <summary>
        /// Minimal Gender Length
        /// </summary>
        public const int GenderMinLength = 10;

        /// <summary>
        /// Maximal Relationship Type Length
        /// </summary>
        public const int RelationshipTypeMaxLength = 30;

        /// <summary>
        /// Minimal Relationship Type Length
        /// </summary>
        public const int RelationshipTypeMinLength = 10;

        /// <summary>
        /// Maximal Description Length
        /// </summary>
        public const int DescriptionMaxLength = 150;

        /// <summary>
        /// Minimal Description Length
        /// </summary>
        public const int DescriptionMinLength = 2;

        /// <summary>
        /// Email of Person Max Length
        /// </summary>
        public const int EmailMaxLength = 50;

        /// <summary>
        /// Email of Person Min Length
        /// </summary>
        public const int EmailMinLength = 50;

        /// <summary>
        /// Require Error Message Text
        /// </summary>
        public const string RequiredErrorMessage = "The {0} field is required!";

        /// <summary>
        /// Input is not long enough or is too long
        /// </summary>
        public const string StringLengthErrorMessage = "The {0} field must be between {2} and {1} characters long!";
    }
}