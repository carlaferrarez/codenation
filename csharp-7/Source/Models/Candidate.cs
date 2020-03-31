using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{

    [Table("candidate")]
    public class Candidate
    {
        [Column("status")]
        [Required]
        public int Status { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime Created_At { get; set; }

        [Column("user_id")]
        [Required]
        public int Userid { get; set; }

        [ForeignKey("Userid")]
        public virtual User Users { get; set; }

        [Column("acceleration_id")]
        [Required]
        public int Accelerationid { get; set; }

        [ForeignKey("Accelerationid")]
        public virtual Acceleration Accelerations { get; set; }

        [Column("company_id")]
        [Required]
        public int Companyid { get; set; }

        [ForeignKey("Companyid")]
        public virtual Company Companies { get; set; }

    }

}
