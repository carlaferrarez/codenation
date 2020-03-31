using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {

        [Column("score", TypeName = "decimal(9,2)")]
        [Required]
        public decimal Score { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime Created_At { get; set; }

        [Column("user_id")]
        [Required]
        public int Userid { get; set; }

        [ForeignKey("Userid")]
        public virtual User Users { get; set; }

        [Column("challenge_id")]
        [Required]
        public int Challengeid { get; set; }

        [ForeignKey("Challengeid")]
        public virtual Challenge Challenges { get; set; }


    }
}
