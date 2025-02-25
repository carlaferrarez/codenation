﻿using Codenation.Challenge.Models;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    internal class CompanyIdComparer : IEqualityComparer<Company>
    {

        public bool Equals(Company x, Company y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Company obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}