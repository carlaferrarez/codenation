using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private CodenationContext _contexto;
        public AccelerationService(CodenationContext context)
        {
            _contexto = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _contexto.Companies
                .Where(x => x.Id == companyId)
                .SelectMany(x => x.Candidates)
                .Select(x => x.Acceleration)
                .Distinct()
                .ToList();
        }

        public Acceleration FindById(int id)
        {
            return _contexto.Accelerations.Find(id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
            var estado = acceleration.Id == 0 ? EntityState.Added : EntityState.Modified;

            _contexto.Entry(acceleration).State = estado;

            _contexto.SaveChanges();

            return acceleration;
        }
    }
}
