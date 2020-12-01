using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class House
    {
        public House()
        {
            HouseInfo = new HashSet<HouseInfo>();
            Registration = new HashSet<Registration>();
        }

        [Key]
        [Column("Id_house")]
        public int IdHouse { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [InverseProperty("IdHouseNavigation")]
        public ICollection<HouseInfo> HouseInfo { get; set; }
        [InverseProperty("IdHouseNavigation")]
        public ICollection<Registration> Registration { get; set; }
    }
}
