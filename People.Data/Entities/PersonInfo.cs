using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Person_info")]
    public partial class PersonInfo
    {
        [Key]
        [Column("Id_people")]
        public long IdPeople { get; set; }
        [StringLength(256)]
        public string Surname { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string Patronymic { get; set; }
        [Column("Id_country_birthday")]
        public int? IdCountryBirthday { get; set; }
        [Column("Id_region_birthday")]
        public int? IdRegionBirthday { get; set; }
        [Column("Id_town_birthday")]
        public int? IdTownBirthday { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        [Column("Date_birthday", TypeName = "datetime")]
        public DateTime? DateBirthday { get; set; }
        [Column("Date_death", TypeName = "datetime")]
        public DateTime? DateDeath { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [ForeignKey("IdCountryBirthday")]
        [InverseProperty("PersonInfo")]
        public Country IdCountryBirthdayNavigation { get; set; }
        [ForeignKey("IdPeople")]
        [InverseProperty("PersonInfo")]
        public Person IdPeopleNavigation { get; set; }
        [ForeignKey("IdRegionBirthday")]
        [InverseProperty("PersonInfo")]
        public Region IdRegionBirthdayNavigation { get; set; }
        [ForeignKey("IdTownBirthday")]
        [InverseProperty("PersonInfo")]
        public Town IdTownBirthdayNavigation { get; set; }
    }
}
