using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Authority
    {
        public Authority()
        {
            AuthorityInfo = new HashSet<AuthorityInfo>();
            Citizenship = new HashSet<Citizenship>();
            Family = new HashSet<Family>();
            Registration = new HashSet<Registration>();
        }

        [Key]
        [Column("Id_authority")]
        public int IdAuthority { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [InverseProperty("IdAuthorityNavigation")]
        public ICollection<AuthorityInfo> AuthorityInfo { get; set; }
        [InverseProperty("IdAuthorityNavigation")]
        public ICollection<Citizenship> Citizenship { get; set; }
        [InverseProperty("IdAuthorityNavigation")]
        public ICollection<Family> Family { get; set; }
        [InverseProperty("IdAuthorityNavigation")]
        public ICollection<Registration> Registration { get; set; }
    }
}
