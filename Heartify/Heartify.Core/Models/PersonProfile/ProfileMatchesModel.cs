namespace Heartify.Core.Models.PersonProfile
{
    public class PersonProfilesModel
	{
		public IEnumerable<PersonProfileInfoViewMatchModel> ProfilesArray { get; set; } = new List<PersonProfileInfoViewMatchModel>();
	}
}
