using Heartify.Constants;

namespace HeartifyDating.Core.Models
{
    public class PersonProfileInfoViewModel
    {
        public PersonProfileInfoViewModel(
            int id,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string gender,
            string wantedGender,
            string relationship,
            string description)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth.ToString(ValidationConstants.DateFormat);
            Gender = gender;
            WantedGender = wantedGender;
            Relationship = relationship;
            Description = description;
        }

        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string DateOfBirth { get; set; } = string.Empty;

        public string Gender { get; set; }

        public string WantedGender { get; set; }

        public string Relationship { get; set; }

        public string Description { get; set; } = string.Empty;

        /*[Required(ErrorMessage = RequiredErrorMessage)]
        public string ProfileImage { get; set; } = string.Empty; //MAKE IMAGE

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string UsernamePicture { get; set; } = string.Empty; //MAKE IMAGE

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string RandomPicture { get; set; } = string.Empty; //MAKE IMAGE */
    }
}