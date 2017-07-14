using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pgSQL.Models
{
    [Table("users")]
    public partial class User
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Column("blog_site_url")]
        public string BlogSiteUrl { get; set; }

        [Column("birthday")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
    }
}
