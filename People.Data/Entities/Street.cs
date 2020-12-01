using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Street
    {
        public Street()
        {
            HouseInfo = new HashSet<HouseInfo>();
            Registration = new HashSet<Registration>();
            StreetInfo = new HashSet<StreetInfo>();
        }

        [Key]
        [Column("Id_street")]
        public int IdStreet { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [InverseProperty("IdStreetNavigation")]
        public ICollection<HouseInfo> HouseInfo { get; set; }
        [InverseProperty("IdStreetNavigation")]
        public ICollection<Registration> Registration { get; set; }
        [InverseProperty("IdStreetNavigation")]
        public ICollection<StreetInfo> StreetInfo { get; set; }
    }
}
