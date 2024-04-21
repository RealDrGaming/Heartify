namespace Heartify.Core.Models.PersonProfile
{
	/// <summary>
	/// Multiple Person Profiles Model
	/// </summary>
    public class PersonProfilesModel
	{
		/// <summary>
		/// Collection of Person Profile Info View Models
		/// </summary>
		public IEnumerable<PersonProfileInfoViewModel> ProfilesArray { get; set; } = new List<PersonProfileInfoViewModel>();
	}
}
