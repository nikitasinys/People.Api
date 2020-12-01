using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Country_info")]
    public partial class CountryInfo
    {
        [Key]
        [Column("Id_dw")]
        public int IdDw { get; set; }
        [Column("Id_country")]
        public int IdCountry { get; set; }
        [Column("Name_country")]
        [StringLength(128)]
        public string NameCountry { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }
        [Column("Relevance_record")]
        public bool? RelevanceRecord { get; set; }

        [ForeignKey("IdCountry")]
        [InverseProperty("CountryInfo")]
        public Country IdCountryNavigation { get; set; }
    }
}
