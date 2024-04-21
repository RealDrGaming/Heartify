namespace Heartify.Core.Models.PersonProfile
{
    public class ProfileMatchesModel
	{
		public IEnumerable<PersonProfileInfoViewModel> ProfilesArray { get; set; } = new List<PersonProfileInfoViewModel>();
	}
}
