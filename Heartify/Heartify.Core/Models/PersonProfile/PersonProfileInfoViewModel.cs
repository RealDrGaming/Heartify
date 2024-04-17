using Heartify.Infrastructure.Constants;

namespace Heartify.Core.Models.PersonProfile
{
    public class PersonProfileInfoViewMatchModel
    {
        public PersonProfileInfoViewMatchModel(
            int id,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string gender,
            string wantedGender,
            string relationship,
            string description,
            string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth.ToString(ValidationConstants.DateFormat);
            Gender = gender;
            WantedGender = wantedGender;
            Relationship = relationship;
            Description = description;
            Email = email;
        }

        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string DateOfBirth { get; set; } = string.Empty;

        public string Gender { get; set; }

        public string WantedGender { get; set; }

        public string Relationship { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}