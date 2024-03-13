using Heartify.Infrastructure.Constants;

namespace Heartify.Core.Models.PersonProfile
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
            /*byte[] profilePicture,
            byte[] usernamePicture,
            byte[] randomPicture,*/
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
            /*ProfilePicture = profilePicture;
            UsernamePicture = usernamePicture;
            RandomPicture = randomPicture;*/
        }

        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string DateOfBirth { get; set; } = string.Empty;

        public string Gender { get; set; }

        public string WantedGender { get; set; }

        public string Relationship { get; set; }

        public string Description { get; set; } = string.Empty;

        /*public byte[] ProfilePicture { get; set; }

        public byte[] UsernamePicture { get; set; }

        public byte[] RandomPicture { get; set; }*/
    }
}