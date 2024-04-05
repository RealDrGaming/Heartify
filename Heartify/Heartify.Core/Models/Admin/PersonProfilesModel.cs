using Heartify.Core.Models.PersonProfile;

namespace Heartify.Core.Models.Admin
{
	public class PersonProfilesModel
	{
		public IEnumerable<PersonProfileInfoViewModel> ProfilesArray { get; set; } = new List<PersonProfileInfoViewModel>();
	}
}
