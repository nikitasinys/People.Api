using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Town
    {
        public Town()
        {
            DistrictInfo = new HashSet<DistrictInfo>();
            PersonInfo = new HashSet<PersonInfo>();
            Registration = new HashSet<Registration>();
            TownInfo = new HashSet<TownInfo>();
        }

        [Key]
        [Column("Id_town")]
        public int IdTown { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [InverseProperty("IdTownNavigation")]
        public ICollection<DistrictInfo> DistrictInfo { get; set; }
        [InverseProperty("IdTownBirthdayNavigation")]
        public ICollection<PersonInfo> PersonInfo { get; set; }
        [InverseProperty("IdTownNavigation")]
        public ICollection<Registration> Registration { get; set; }
        [InverseProperty("IdTownNavigation")]
        public ICollection<TownInfo> TownInfo { get; set; }
    }
}
