using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private CodenationContext _contexto;
        public ChallengeService(CodenationContext context)
        {
            _contexto = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _contexto.Candidates
                .Where(x => x.AccelerationId == accelerationId && x.UserId == userId)
                .Select(x => x.Acceleration.Challenge)
                .Distinct()
                .ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            var estado = challenge.Id == 0 ? EntityState.Added : EntityState.Modified;

            _contexto.Entry(challenge).State = estado;

            _contexto.SaveChanges();

            return challenge;
        }
    }
}