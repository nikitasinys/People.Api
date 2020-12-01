using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    [Table("Registration_type")]
    public partial class RegistrationType
    {
        public RegistrationType()
        {
            Registration = new HashSet<Registration>();
        }

        [Key]
        [Column("Id_type_registration")]
        public int IdTypeRegistration { get; set; }
        [Required]
        [Column("Description_registration")]
        [StringLength(256)]
        public string DescriptionRegistration { get; set; }

        [InverseProperty("IdTypeRegistrationNavigation")]
        public ICollection<Registration> Registration { get; set; }
    }
}
