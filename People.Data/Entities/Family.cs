using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Family
    {
        [Key]
        [Column("Id_family")]
        public long IdFamily { get; set; }
        [Column("Id_spouse1")]
        public long? IdSpouse1 { get; set; }
        [Column("Id_spouse2")]
        public long? IdSpouse2 { get; set; }
        [Column("Id_authority")]
        public int? IdAuthority { get; set; }
        [Column("Date_registration", TypeName = "datetime")]
        public DateTime? DateRegistration { get; set; }
        [Column("Date_divorce", TypeName = "datetime")]
        public DateTime? DateDivorce { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [ForeignKey("IdAuthority")]
        [InverseProperty("Family")]
        public Authority IdAuthorityNavigation { get; set; }
        [ForeignKey("IdSpouse1")]
        [InverseProperty("FamilyIdSpouse1Navigation")]
        public Person IdSpouse1Navigation { get; set; }
        [ForeignKey("IdSpouse2")]
        [InverseProperty("FamilyIdSpouse2Navigation")]
        public Person IdSpouse2Navigation { get; set; }
    }
}
