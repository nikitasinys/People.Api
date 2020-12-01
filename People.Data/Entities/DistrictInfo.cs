using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("District_info")]
    public partial class DistrictInfo
    {
        [Key]
        [Column("Id_dw")]
        public int IdDw { get; set; }
        [Column("Id_district")]
        public int IdDistrict { get; set; }
        [Column("Id_town")]
        public int? IdTown { get; set; }
        [Column("Name_district")]
        [StringLength(128)]
        public string NameDistrict { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }
        [Column("Relevance_record")]
        public bool? RelevanceRecord { get; set; }

        [ForeignKey("IdDistrict")]
        [InverseProperty("DistrictInfo")]
        public District IdDistrictNavigation { get; set; }
        [ForeignKey("IdTown")]
        [InverseProperty("DistrictInfo")]
        public Town IdTownNavigation { get; set; }
    }
}
