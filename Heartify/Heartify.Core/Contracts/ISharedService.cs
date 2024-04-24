namespace Heartify.Core.Contracts
{
    public interface ISharedService
    {
        Task DeletePersonProfileAsync(int personProfileId);
        Task<bool> ExistsByIdApprovedAsync(string personProfileId);
        Task<bool> ExistsByIdAllAsync(string personProfileId);
    }
}
