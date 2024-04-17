using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Heartify.Infrastructure.Data.Common;
using Heartify.Infrastructure.Data.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var like = new Like
            {
                LikerId = userId,
                LikedProfileId = personProfileId
            };

            var likeExisting = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == like.LikedProfileId && l.LikerId == like.LikerId);

            if (likeExisting == null)
            {
                await repository.AddAsync(like);
                await repository.SaveChangesAsync();
            }
        }

        public async Task DeclineProfileAsync(string userId, int personProfileId)
        {
            var otherUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.Id == personProfileId);
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var likeToRemove = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == currentUserProfile.Id && l.LikerId == otherUserProfile.DaterId);

            if (likeToRemove != null)
            {
                await repository.DeletePersonProfileAsync<Like>(likeToRemove.Id);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PersonProfileInfoViewModel>> GetPendingRequests(string userId)
        {
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var likedProfiles = await repository.AllReadOnly<Like>()
                .Where(l => l.LikerId == userId)
                .Select(l => l.LikedProfileId)
                .ToListAsync();

            var likedProfilesDaterIds = await repository.AllReadOnly<PersonProfile>()
                .Where(pp => likedProfiles
                    .Contains(pp.Id))
                .Select(pp => pp.DaterId)
                .ToListAsync();

            var pendingRequests = await repository.AllReadOnly<Like>()
                .Where(l => l.LikedProfileId == currentUserProfile.Id)
                .Where(l => l.LikerId != userId)
                .Where(l => !likedProfilesDaterIds.Contains(l.LikerId))
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

            return pendingRequests ?? null;
        }

        public async Task<IEnumerable<PersonProfileInfoViewMatchModel>> GetMatches(string userId)
        {
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var likedProfiles = await repository.AllReadOnly<Like>()
                .Where(l => l.LikerId == userId)
                .Select(l => l.LikedProfileId)
                .ToListAsync();

            var likedProfilesDaterIds = await repository.AllReadOnly<PersonProfile>()
                .Where(pp => likedProfiles
                    .Contains(pp.Id))
                .Select(pp => pp.DaterId)
                .ToListAsync();

            var matches = await repository.AllReadOnly<Like>()
                .Where(l => l.LikedProfileId == currentUserProfile.Id)
                .Where(l => l.LikerId != userId)
                .Where(l => likedProfilesDaterIds.Contains(l.LikerId))
                .Join(
                    repository.AllReadOnly<PersonProfile>(),
                    like => like.LikerId,
                    profile => profile.DaterId,
                    (like, profile) => new PersonProfileInfoViewMatchModel(
                    profile.Id,
                    profile.FirstName,
                    profile.LastName,
                    profile.DateOfBirth,
                    profile.Gender.GenderName,
                    profile.WantedGender.GenderName,
                    profile.Relationship.RelationshipType,
                    profile.Description,
                    profile.Dater.Email
                ))
                .ToListAsync();

            return matches ?? null;
        }

        public async Task RemoveMatchAsync(string userId, int personProfileId)
        {
            var otherUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.Id == personProfileId);
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>().FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var likeToRemove1 = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == currentUserProfile.Id && l.LikerId == otherUserProfile.DaterId);
            var likeToRemove2 = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == otherUserProfile.Id && l.LikerId == currentUserProfile.DaterId);

            if (likeToRemove1 != null && likeToRemove2 != null)
            {
                await repository.DeletePersonProfileAsync<Like>(likeToRemove1.Id);
                await repository.DeletePersonProfileAsync<Like>(likeToRemove2.Id);
                await repository.SaveChangesAsync();
            }
        }
    }
}
