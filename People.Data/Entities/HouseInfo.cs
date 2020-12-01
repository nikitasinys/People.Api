using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("House_info")]
    public partial class HouseInfo
    {
        [Key]
        [Column("Id_dw")]
        public int IdDw { get; set; }
        [Column("Id_house")]
        public int IdHouse { get; set; }
        [Column("Id_street")]
        public int? IdStreet { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }
        [Column("Relevance_record")]
        public bool? RelevanceRecord { get; set; }

        [ForeignKey("IdHouse")]
        [InverseProperty("HouseInfo")]
        public House IdHouseNavigation { get; set; }
        [ForeignKey("IdStreet")]
        [InverseProperty("HouseInfo")]
        public Street IdStreetNavigation { get; set; }
    }
}
