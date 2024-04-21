namespace Heartify.Core.Models.PersonProfile
{
    /// <summary>
    /// Multiple Person Profiles Model
    /// </summary>
    public class ProfileMatchesModel
    {
        /// <summary>
        /// Collection of Person Profile Info View Match Models
        /// </summary>
        public IEnumerable<PersonProfileInfoViewMatchModel> ProfilesArray { get; set; } = new List<PersonProfileInfoViewMatchModel>();
	}
}
