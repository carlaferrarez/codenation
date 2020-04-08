using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private CodenationContext _contexto;
        public CompanyService(CodenationContext context)
        {
            _contexto = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _contexto.Accelerations
                .Where(x => x.Id == accelerationId)
                .SelectMany(x => x.Candidates)
                .Select(x => x.Company)
                .Distinct()
                .ToList();
        }

        public Company FindById(int id)
        {
            return _contexto.Companies.Find(id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _contexto.Users
                .Where(x => x.Id == userId)
                .SelectMany(x => x.Candidates)
                .Select(x => x.Company)
                .Distinct()
                .ToList();
        }

        public Company Save(Company company)
        {
            var state = _contexto.Entry(company).State;

            var existe = _contexto.Companies.AsNoTracking().Where(x => x.Id == company.Id);

            if (existe == null)
                _contexto.Add(company);
            else
                _contexto.Update(company);

            _contexto.SaveChanges();

            return company;
        }
    }
}