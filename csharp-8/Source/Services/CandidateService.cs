using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private CodenationContext _contexto;
        public CandidateService(CodenationContext context)
        {
            _contexto = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _contexto.Accelerations
                .Where(x => x.Id == accelerationId)
                .SelectMany(x => x.Candidates)
                .Distinct()
                .ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _contexto.Companies
                .Where(x => x.Id == companyId)
                .SelectMany(x => x.Candidates)
                .Distinct()
                .ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _contexto.Candidates.Find(userId, accelerationId, companyId);
        }

        public Candidate Save(Candidate candidate)
        {
            //var state = _contexto.Entry(candidate).State;
            var existe = _contexto.Candidates.Find(candidate.AccelerationId, candidate.CompanyId, candidate.UserId);

            if (existe == null)
                _contexto.Add(candidate);
            else
                //_contexto.Update(candidate);
                existe.Status = candidate.Status;

            _contexto.SaveChanges();

            return candidate;
        }
    }
}
