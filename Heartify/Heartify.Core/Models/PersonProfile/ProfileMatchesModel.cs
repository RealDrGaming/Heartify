namespace Heartify.Core.Models.PersonProfile
{
    public class PersonProfilesModel
	{
		public IEnumerable<PersonProfileInfoViewModel> ProfilesArray { get; set; } = new List<PersonProfileInfoViewModel>();
	}
}
