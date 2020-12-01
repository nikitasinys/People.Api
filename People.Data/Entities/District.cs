using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class District
    {
        public District()
        {
            DistrictInfo = new HashSet<DistrictInfo>();
            Registration = new HashSet<Registration>();
            StreetInfo = new HashSet<StreetInfo>();
        }

        [Key]
        [Column("Id_district")]
        public int IdDistrict { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [InverseProperty("IdDistrictNavigation")]
        public ICollection<DistrictInfo> DistrictInfo { get; set; }
        [InverseProperty("IdDistrictNavigation")]
        public ICollection<Registration> Registration { get; set; }
        [InverseProperty("IdDistrictNavigation")]
        public ICollection<StreetInfo> StreetInfo { get; set; }
    }
}
