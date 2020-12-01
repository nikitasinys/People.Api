using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Street_info")]
    public partial class StreetInfo
    {
        [Key]
        [Column("Id_dw")]
        public int IdDw { get; set; }
        [Column("Id_street")]
        public int IdStreet { get; set; }
        [Column("Id_district")]
        public int? IdDistrict { get; set; }
        [Column("Name_street")]
        [StringLength(128)]
        public string NameStreet { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }
        [Column("Relevance_record")]
        public bool? RelevanceRecord { get; set; }

        [ForeignKey("IdDistrict")]
        [InverseProperty("StreetInfo")]
        public District IdDistrictNavigation { get; set; }
        [ForeignKey("IdStreet")]
        [InverseProperty("StreetInfo")]
        public Street IdStreetNavigation { get; set; }
    }
}
