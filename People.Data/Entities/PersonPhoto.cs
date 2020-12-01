using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Person_photo")]
    public partial class PersonPhoto
    {
        [Key]
        [Column("Hash_photo")]
        public long HashPhoto { get; set; }
        [Column("Id_people")]
        public long? IdPeople { get; set; }
        [Column("Path_to_photo")]
        [StringLength(256)]
        public string PathToPhoto { get; set; }
        [Column("Date_photo", TypeName = "datetime")]
        public DateTime? DatePhoto { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [ForeignKey("IdPeople")]
        [InverseProperty("PersonPhoto")]
        public Person IdPeopleNavigation { get; set; }
    }
}
