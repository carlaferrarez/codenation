using Codenation.Challenge.Models;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    internal class CandidateIdComparer : IEqualityComparer<Candidate>
    {

        public bool Equals(Candidate x, Candidate y)
        {
            return x.AccelerationId == y.AccelerationId && x.CompanyId == y.CompanyId && x.UserId == y.UserId;
        }

        public int GetHashCode(Candidate obj)
        {
            return obj.CompanyId.GetHashCode();
        }
    }
}