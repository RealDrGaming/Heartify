using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Heartify.Infrastructure.Constants;
using Heartify.Infrastructure.Data.Common;
using Heartify.Infrastructure.Data.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Heartify.Core.Services
{
    public class DatingService : IDatingService
    {
        private readonly IRepository repository;

        public DatingService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<PersonProfileInfoViewModel>> GetNeededProfilesForInspectionAsync(string userId)
        {
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>()
                    .Where(pp => pp.IsApproved)
                    .FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var likedProfiles = await repository.AllReadOnly<Like>()
                .Where(like => like.LikerId == userId)
                .Select(like => like.LikedProfileId)
                .ToListAsync();

            var model = await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .Where(pp => pp.GenderId == currentUserProfile.WantedGenderId)
                .Where(pp => pp.DaterId != userId)
                .Where(pp => !likedProfiles.Contains(pp.Id))
                .Select(pp => new PersonProfileInfoViewModel(
                    pp.Id,
                    pp.FirstName,
                    pp.LastName,
                    pp.DateOfBirth,
                    pp.Gender.GenderName,
                    pp.WantedGender.GenderName,
                    pp.Relationship.RelationshipType,
                    /*pp.ProfilePicture,
                    pp.UsernamePicture,
                    pp.RandomPicture,*/
                    pp.Description
                    ))
                .ToListAsync();

            return model ?? null;
        }

        public async Task LikeProfileAsync(string userId, int personProfileId)
        {
            var like = new Like
            {
                LikerId = userId,
                LikedProfileId = personProfileId
            };

            await repository.AddAsync(like);
        }

        public async Task DeclineProfileAsync(string userId, int personProfileId)
        {
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.Id == personProfileId);
            var currentUser = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var likeToRemove = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == currentUser.Id && l.LikerId == currentUserProfile.DaterId);

            if (likeToRemove != null)
            {
                await repository.DeleteAsync<Like>(likeToRemove.Id);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PersonProfileInfoViewModel>> GetPendingRequests(string userId)
        {
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var usersWhoLikedCurrentProfile = await repository.AllReadOnly<Like>()
                .Where(l => l.LikedProfileId == currentUserProfile.Id)
                .Where(l => l.LikerId != userId)
                .Join(
                    repository.AllReadOnly<PersonProfile>(),
                    like => like.LikerId,
                    profile => profile.DaterId,
                    (like, profile) => new PersonProfileInfoViewModel(
                    profile.Id,
                    profile.FirstName,
                    profile.LastName,
                    profile.DateOfBirth,
                    profile.Gender.GenderName,
                    profile.WantedGender.GenderName,
                    profile.Relationship.RelationshipType,
                    profile.Description
                ))
                .ToListAsync();

            return usersWhoLikedCurrentProfile ?? null;
        }
    }
}
