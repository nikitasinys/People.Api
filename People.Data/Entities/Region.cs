using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Region
    {
        public Region()
        {
            PersonInfo = new HashSet<PersonInfo>();
            RegionInfo = new HashSet<RegionInfo>();
            Registration = new HashSet<Registration>();
            TownInfo = new HashSet<TownInfo>();
        }

        [Key]
        [Column("Id_region")]
        public int IdRegion { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [InverseProperty("IdRegionBirthdayNavigation")]
        public ICollection<PersonInfo> PersonInfo { get; set; }
        [InverseProperty("IdRegionNavigation")]
        public ICollection<RegionInfo> RegionInfo { get; set; }
        [InverseProperty("IdRegionNavigation")]
        public ICollection<Registration> Registration { get; set; }
        [InverseProperty("IdRegionNavigation")]
        public ICollection<TownInfo> TownInfo { get; set; }
    }
}
