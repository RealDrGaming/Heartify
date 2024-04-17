namespace Heartify.Core.Models.PersonProfile
{
    public class ProfileMatchesModel
	{
		public IEnumerable<PersonProfileInfoViewMatchModel> ProfilesArray { get; set; } = new List<PersonProfileInfoViewMatchModel>();
	}
}
