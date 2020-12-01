using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Town_info")]
    public partial class TownInfo
    {
        [Key]
        [Column("Id_dw")]
        public int IdDw { get; set; }
        [Column("Id_town")]
        public int IdTown { get; set; }
        [Column("Id_region")]
        public int? IdRegion { get; set; }
        [Column("Name_town")]
        [StringLength(128)]
        public string NameTown { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }
        [Column("Relevance_record")]
        public bool? RelevanceRecord { get; set; }

        [ForeignKey("IdRegion")]
        [InverseProperty("TownInfo")]
        public Region IdRegionNavigation { get; set; }
        [ForeignKey("IdTown")]
        [InverseProperty("TownInfo")]
        public Town IdTownNavigation { get; set; }
    }
}
