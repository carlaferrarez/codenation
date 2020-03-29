using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Key]
        [Column("id")]
        [Required]
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

        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Acceleration> Accelerations { get; set; }


    }
}
