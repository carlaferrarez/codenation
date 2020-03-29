using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{

    [Table("acceleration")]
    public class Acceleration
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("slug")]
        [StringLength(50)]
        [Required]
        public string Slug { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime Created_At { get; set; }

        [Column("challenge_id")]
        [Required]
        public int Challenge_id { get; set; }

        [ForeignKey("challenge_id")]
        public virtual Challenge Challenges { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }


    }
}
