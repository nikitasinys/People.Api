using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Region_info")]
    public partial class RegionInfo
    {
        [Key]
        [Column("Id_dw")]
        public int IdDw { get; set; }
        [Column("Id_region")]
        public int IdRegion { get; set; }
        [Column("Id_country")]
        public int? IdCountry { get; set; }
        [Column("Name_region")]
        [StringLength(128)]
        public string NameRegion { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }
        [Column("Relevance_record")]
        public bool? RelevanceRecord { get; set; }

        [ForeignKey("IdCountry")]
        [InverseProperty("RegionInfo")]
        public Country IdCountryNavigation { get; set; }
        [ForeignKey("IdRegion")]
        [InverseProperty("RegionInfo")]
        public Region IdRegionNavigation { get; set; }
    }
}
