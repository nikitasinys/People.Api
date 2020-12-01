using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Citizenship
    {
        [Key]
        [Column("Id_record_citizenship")]
        public long IdRecordCitizenship { get; set; }
        [Column("Id_people")]
        public long? IdPeople { get; set; }
        [Column("Id_country")]
        public int? IdCountry { get; set; }
        [Column("Id_authority")]
        public int? IdAuthority { get; set; }
        [Column("Date_issue", TypeName = "datetime")]
        public DateTime? DateIssue { get; set; }
        [Column("Date_divorce", TypeName = "datetime")]
        public DateTime? DateDivorce { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [ForeignKey("IdAuthority")]
        [InverseProperty("Citizenship")]
        public Authority IdAuthorityNavigation { get; set; }
        [ForeignKey("IdCountry")]
        [InverseProperty("Citizenship")]
        public Country IdCountryNavigation { get; set; }
        [ForeignKey("IdPeople")]
        [InverseProperty("Citizenship")]
        public Person IdPeopleNavigation { get; set; }
    }
}
