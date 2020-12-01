using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Country
    {
        public Country()
        {
            Citizenship = new HashSet<Citizenship>();
            CountryInfo = new HashSet<CountryInfo>();
            PersonInfo = new HashSet<PersonInfo>();
            RegionInfo = new HashSet<RegionInfo>();
            Registration = new HashSet<Registration>();
        }

        [Key]
        [Column("Id_country")]
        public int IdCountry { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [InverseProperty("IdCountryNavigation")]
        public ICollection<Citizenship> Citizenship { get; set; }
        [InverseProperty("IdCountryNavigation")]
        public ICollection<CountryInfo> CountryInfo { get; set; }
        [InverseProperty("IdCountryBirthdayNavigation")]
        public ICollection<PersonInfo> PersonInfo { get; set; }
        [InverseProperty("IdCountryNavigation")]
        public ICollection<RegionInfo> RegionInfo { get; set; }
        [InverseProperty("IdCountryNavigation")]
        public ICollection<Registration> Registration { get; set; }
    }
}
