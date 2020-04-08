using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private CodenationContext _contexto;
        public SubmissionService(CodenationContext context)
        {
            _contexto = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return _contexto.Candidates
                .Where(x => x.AccelerationId == accelerationId)
                .Select(x => x.User)
                .SelectMany(x => x.Submissions)
                .Where(x => x.ChallengeId == challengeId)
                .Distinct()
                .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _contexto.Challenges
                .Where(x => x.Id == challengeId)
                .SelectMany(x => x.Submissions)
                .Select(x => x.Score)
                .OrderByDescending(x => x)
                .First();
        }

        public Submission Save(Submission submission)
        {
           // var state = _contexto.Entry(submission).State;

            var existe = _contexto.Submissions.Find(submission.ChallengeId, submission.UserId);

            if (existe == null)
                _contexto.Add(submission);
            else
                //_contexto.Update(submission);
                existe.Score = submission.Score;

            _contexto.SaveChanges();

            return submission;
        }
    }
}
