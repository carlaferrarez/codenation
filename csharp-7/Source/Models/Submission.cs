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
        public double Status { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime Created_At { get; set; }

        [Column("user_id")]
        [Required]
        public int User_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User Users { get; set; }

        [Column("challenge_id")]
        [Required]
        public int Challenge_id { get; set; }

        [ForeignKey("challenge_id")]
        public virtual Challenge Challenges { get; set; }


    }
}
