using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Heartify.Infrastructure.Data.Common;
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


        public async Task<IEnumerable<PersonProfileInfoViewModel>> GetNeededProfilesAsync(int personProfileId)
        {
            var wantedGender = await repository.AllReadOnly<PersonProfile>()
                    .Where(pp => pp.IsApproved)
                    .FirstOrDefaultAsync(pp => pp.Id == personProfileId).Result.WantedGender.GenderName;

            var model = await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .Where(pp => pp.Gender == wantedGender);

            return model;
        }
    }
}
