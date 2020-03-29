﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codenation.Challenge.Models.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>

    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(x => new {x.Company_id, x.Acceleration_id, x.User_id});
        
        }
    }
}
