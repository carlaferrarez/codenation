using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private CodenationContext _contexto;
        public UserService(CodenationContext context)
        {
            _contexto = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _contexto.Accelerations
                .Where(x => x.Name == name)
                .SelectMany(x => x.Candidates)
                .Select(x => x.User)
                .Distinct()
                .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _contexto.Companies
                .Where(x => x.Id == companyId)
                .SelectMany(x => x.Candidates)
                .Select(x => x.User)
                .Distinct()
                .ToList();
        }

        public User FindById(int id)
        {
            return _contexto.Users.Find(id);
        }

        public User Save(User user)
        {
            var estado = user.Id == 0 ? EntityState.Added : EntityState.Modified;
            
            _contexto.Entry(user).State = estado;
            
            _contexto.SaveChanges();

            return user;
        }
    }
}
