using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("company")]
    public class Company
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("slug")]
        [Required]
        [StringLength(50)]
        public string Slug { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime Created_At { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }

    }
}
