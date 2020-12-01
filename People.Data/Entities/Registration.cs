using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Registration
    {
        [Key]
        [Column("Id_registration")]
        public long IdRegistration { get; set; }
        [Column("Id_people")]
        public long? IdPeople { get; set; }
        [Column("Id_country")]
        public int? IdCountry { get; set; }
        [Column("Id_region")]
        public int? IdRegion { get; set; }
        [Column("Id_town")]
        public int? IdTown { get; set; }
        [Column("Id_district")]
        public int? IdDistrict { get; set; }
        [Column("Id_street")]
        public int? IdStreet { get; set; }
        [Column("Id_house")]
        public int? IdHouse { get; set; }
        [Column("Num_housing")]
        public int? NumHousing { get; set; }
        [Column("Num_flat")]
        public int? NumFlat { get; set; }
        [Column("Id_type_registration")]
        public int? IdTypeRegistration { get; set; }
        [Column("Id_authority")]
        public int? IdAuthority { get; set; }
        [Column("Date_issue", TypeName = "datetime")]
        public DateTime? DateIssue { get; set; }
        [Column("Date_termination", TypeName = "datetime")]
        public DateTime? DateTermination { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [ForeignKey("IdAuthority")]
        [InverseProperty("Registration")]
        public Authority IdAuthorityNavigation { get; set; }
        [ForeignKey("IdCountry")]
        [InverseProperty("Registration")]
        public Country IdCountryNavigation { get; set; }
        [ForeignKey("IdDistrict")]
        [InverseProperty("Registration")]
        public District IdDistrictNavigation { get; set; }
        [ForeignKey("IdHouse")]
        [InverseProperty("Registration")]
        public House IdHouseNavigation { get; set; }
        [ForeignKey("IdPeople")]
        [InverseProperty("Registration")]
        public Person IdPeopleNavigation { get; set; }
        [ForeignKey("IdRegion")]
        [InverseProperty("Registration")]
        public Region IdRegionNavigation { get; set; }
        [ForeignKey("IdStreet")]
        [InverseProperty("Registration")]
        public Street IdStreetNavigation { get; set; }
        [ForeignKey("IdTown")]
        [InverseProperty("Registration")]
        public Town IdTownNavigation { get; set; }
        [ForeignKey("IdTypeRegistration")]
        [InverseProperty("Registration")]
        public RegistrationType IdTypeRegistrationNavigation { get; set; }
    }
}
