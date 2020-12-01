using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Authority_type")]
    public partial class AuthorityType
    {
        public AuthorityType()
        {
            AuthorityInfo = new HashSet<AuthorityInfo>();
        }

        [Key]
        [Column("Type_authority")]
        public int TypeAuthority { get; set; }
        [Required]
        [Column("Name_type")]
        [StringLength(256)]
        public string NameType { get; set; }

        [InverseProperty("TypeAuthorityNavigation")]
        public ICollection<AuthorityInfo> AuthorityInfo { get; set; }
    }
}
