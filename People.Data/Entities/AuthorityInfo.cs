using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Authority_info")]
    public partial class AuthorityInfo
    {
        [Key]
        [Column("Id_dw")]
        public int IdDw { get; set; }
        [Column("Id_authority")]
        public int IdAuthority { get; set; }
        [Column("Type_authority")]
        public int? TypeAuthority { get; set; }
        [Column("Name_authority")]
        [StringLength(50)]
        public string NameAuthority { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }
        [Column("Relevance_record")]
        public bool? RelevanceRecord { get; set; }

        [ForeignKey("IdAuthority")]
        [InverseProperty("AuthorityInfo")]
        public Authority IdAuthorityNavigation { get; set; }
        [ForeignKey("TypeAuthority")]
        [InverseProperty("AuthorityInfo")]
        public AuthorityType TypeAuthorityNavigation { get; set; }
    }
}
