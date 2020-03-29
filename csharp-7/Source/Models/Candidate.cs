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
        public int User_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User Users { get; set; }

        [Column("acceleration_id")]
        [Required]
        public int Acceleration_id { get; set; }

        [ForeignKey("acceleration_id")]
        public virtual Acceleration Accelerations { get; set; }

        [Column("company_id")]
        [Required]
        public int Company_id { get; set; }

        [ForeignKey("company_id")]
        public virtual Company Companies { get; set; }

    }

}
