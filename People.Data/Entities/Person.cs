using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Data.Entities
{
    public partial class Person
    {
        public Person()
        {
            Citizenship = new HashSet<Citizenship>();
            FamilyIdSpouse1Navigation = new HashSet<Family>();
            FamilyIdSpouse2Navigation = new HashSet<Family>();
            PersonPhoto = new HashSet<PersonPhoto>();
            Registration = new HashSet<Registration>();
        }

        public long Id { get; set; }
        [Column("Datetime_added", TypeName = "datetime")]
        public DateTime? DatetimeAdded { get; set; }

        [InverseProperty("IdPeopleNavigation")]
        public PersonInfo PersonInfo { get; set; }
        [InverseProperty("IdPeopleNavigation")]
        public ICollection<Citizenship> Citizenship { get; set; }
        [InverseProperty("IdSpouse1Navigation")]
        public ICollection<Family> FamilyIdSpouse1Navigation { get; set; }
        [InverseProperty("IdSpouse2Navigation")]
        public ICollection<Family> FamilyIdSpouse2Navigation { get; set; }
        [InverseProperty("IdPeopleNavigation")]
        public ICollection<PersonPhoto> PersonPhoto { get; set; }
        [InverseProperty("IdPeopleNavigation")]
        public ICollection<Registration> Registration { get; set; }
    }
}
