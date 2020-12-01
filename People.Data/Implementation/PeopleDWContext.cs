using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace People.Data.Entities
{
    public partial class PeopleDWContext : DbContext
    {
        public PeopleDWContext()
        {
        }

        public PeopleDWContext(DbContextOptions<PeopleDWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authority> Authority { get; set; }
        public virtual DbSet<AuthorityInfo> AuthorityInfo { get; set; }
        public virtual DbSet<AuthorityType> AuthorityType { get; set; }
        public virtual DbSet<Citizenship> Citizenship { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryInfo> CountryInfo { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DistrictInfo> DistrictInfo { get; set; }
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseInfo> HouseInfo { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonInfo> PersonInfo { get; set; }
        public virtual DbSet<PersonPhoto> PersonPhoto { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionInfo> RegionInfo { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<RegistrationType> RegistrationType { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<StreetInfo> StreetInfo { get; set; }
        public virtual DbSet<Town> Town { get; set; }
        public virtual DbSet<TownInfo> TownInfo { get; set; }
		/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
              //  optionsBuilder.UseSqlServer("Data Source=ACERV5-W;Initial Catalog=peopleDw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
		*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authority>(entity =>
            {
                entity.Property(e => e.IdAuthority).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AuthorityInfo>(entity =>
            {
                entity.HasIndex(e => e.TypeAuthority)
                    .HasName("Relationship_11_FK");

                entity.Property(e => e.IdDw).ValueGeneratedOnAdd();

                entity.Property(e => e.NameAuthority).IsUnicode(false);

                entity.HasOne(d => d.IdAuthorityNavigation)
                    .WithMany(p => p.AuthorityInfo)
                    .HasForeignKey(d => d.IdAuthority)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Authority_info_Authority");

                entity.HasOne(d => d.TypeAuthorityNavigation)
                    .WithMany(p => p.AuthorityInfo)
                    .HasForeignKey(d => d.TypeAuthority)
                    .HasConstraintName("FK_AUTHORIT_RELATIONS_TYPES_AU");
            });

            modelBuilder.Entity<AuthorityType>(entity =>
            {
                entity.Property(e => e.TypeAuthority).ValueGeneratedOnAdd();

                entity.Property(e => e.NameType).IsUnicode(false);
            });

            modelBuilder.Entity<Citizenship>(entity =>
            {
                entity.HasIndex(e => e.IdAuthority)
                    .HasName("Relationship_13_FK");

                entity.HasIndex(e => e.IdCountry)
                    .HasName("Relationship_16_FK");

                entity.HasIndex(e => e.IdPeople)
                    .HasName("Relationship_17_FK");

                entity.Property(e => e.IdRecordCitizenship).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdAuthorityNavigation)
                    .WithMany(p => p.Citizenship)
                    .HasForeignKey(d => d.IdAuthority)
                    .HasConstraintName("FK_CITIZENS_RELATIONS_AUTHORIT");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Citizenship)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_CITIZENS_RELATIONS_COUNTRIE");

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithMany(p => p.Citizenship)
                    .HasForeignKey(d => d.IdPeople)
                    .HasConstraintName("FK_CITIZENS_RELATIONS_peopleDWS");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.IdCountry).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CountryInfo>(entity =>
            {
                entity.Property(e => e.IdDw).ValueGeneratedOnAdd();

                entity.Property(e => e.NameCountry).IsUnicode(false);

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.CountryInfo)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country_info_CountryR");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.IdDistrict).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DistrictInfo>(entity =>
            {
                entity.HasIndex(e => e.IdTown)
                    .HasName("Relationship_10_FK");

                entity.Property(e => e.IdDw).ValueGeneratedOnAdd();

                entity.Property(e => e.NameDistrict).IsUnicode(false);

                entity.HasOne(d => d.IdDistrictNavigation)
                    .WithMany(p => p.DistrictInfo)
                    .HasForeignKey(d => d.IdDistrict)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_info_DistrictR");

                entity.HasOne(d => d.IdTownNavigation)
                    .WithMany(p => p.DistrictInfo)
                    .HasForeignKey(d => d.IdTown)
                    .HasConstraintName("FK_DISTRICT_RELATIONS_TOWNS");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasIndex(e => e.IdAuthority)
                    .HasName("Relationship_15_FK");

                entity.HasIndex(e => e.IdSpouse1)
                    .HasName("Relationship_2_FK");

                entity.HasIndex(e => e.IdSpouse2)
                    .HasName("Relationship_3_FK");

                entity.Property(e => e.IdFamily).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdAuthorityNavigation)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.IdAuthority)
                    .HasConstraintName("FK_FAMILIES_RELATIONS_AUTHORIT");

                entity.HasOne(d => d.IdSpouse1Navigation)
                    .WithMany(p => p.FamilyIdSpouse1Navigation)
                    .HasForeignKey(d => d.IdSpouse1)
                    .HasConstraintName("FK_SPOUSE2_FAMILIES_vs_peopleDWS");

                entity.HasOne(d => d.IdSpouse2Navigation)
                    .WithMany(p => p.FamilyIdSpouse2Navigation)
                    .HasForeignKey(d => d.IdSpouse2)
                    .HasConstraintName("FK_SPOUSE1_FAMILIES_vs_peopleDWS");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.IdHouse).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<HouseInfo>(entity =>
            {
                entity.HasIndex(e => e.IdStreet)
                    .HasName("Relationship_22_FK");

                entity.Property(e => e.IdDw).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdHouseNavigation)
                    .WithMany(p => p.HouseInfo)
                    .HasForeignKey(d => d.IdHouse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_info_HouseR");

                entity.HasOne(d => d.IdStreetNavigation)
                    .WithMany(p => p.HouseInfo)
                    .HasForeignKey(d => d.IdStreet)
                    .HasConstraintName("FK_House_info_Street");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PersonInfo>(entity =>
            {
                entity.HasIndex(e => e.IdCountryBirthday)
                    .HasName("Relationship_19_FK");

                entity.HasIndex(e => e.IdRegionBirthday)
                    .HasName("Relationship_20_FK");

                entity.HasIndex(e => e.IdTownBirthday)
                    .HasName("Relationship_21_FK");

                entity.Property(e => e.IdPeople).ValueGeneratedOnAdd();

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Patronymic).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);

                entity.HasOne(d => d.IdCountryBirthdayNavigation)
                    .WithMany(p => p.PersonInfo)
                    .HasForeignKey(d => d.IdCountryBirthday)
                    .HasConstraintName("FK_peopleDWS_RELATIONS_COUNTRIE");

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithOne(p => p.PersonInfo)
                    .HasForeignKey<PersonInfo>(d => d.IdPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_People_info_People");

                entity.HasOne(d => d.IdRegionBirthdayNavigation)
                    .WithMany(p => p.PersonInfo)
                    .HasForeignKey(d => d.IdRegionBirthday)
                    .HasConstraintName("FK_peopleDWS_RELATIONS_REGIONS");

                entity.HasOne(d => d.IdTownBirthdayNavigation)
                    .WithMany(p => p.PersonInfo)
                    .HasForeignKey(d => d.IdTownBirthday)
                    .HasConstraintName("FK_peopleDWS_RELATIONS_TOWNS");
            });

            modelBuilder.Entity<PersonPhoto>(entity =>
            {
                entity.HasIndex(e => e.IdPeople)
                    .HasName("Relationship_1_FK");

                entity.Property(e => e.HashPhoto).ValueGeneratedOnAdd();

                entity.Property(e => e.PathToPhoto).IsUnicode(false);

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithMany(p => p.PersonPhoto)
                    .HasForeignKey(d => d.IdPeople)
                    .HasConstraintName("FK_PHOTOS_P_RELATIONS_peopleDWS");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.IdRegion).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<RegionInfo>(entity =>
            {
                entity.HasIndex(e => e.IdCountry)
                    .HasName("Relationship_8_FK");

                entity.Property(e => e.IdDw).ValueGeneratedOnAdd();

                entity.Property(e => e.NameRegion).IsUnicode(false);

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.RegionInfo)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_REGIONS_RELATIONS_COUNTRIE");

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.RegionInfo)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Region_info_RegionR");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasIndex(e => e.IdAuthority)
                    .HasName("Relationship_14_FK");

                entity.HasIndex(e => e.IdCountry)
                    .HasName("Relationship_4_FK");

                entity.HasIndex(e => e.IdDistrict)
                    .HasName("Relationship_7_FK");

                entity.HasIndex(e => e.IdHouse)
                    .HasName("Relationship_25_FK");

                entity.HasIndex(e => e.IdPeople)
                    .HasName("Relationship_18_FK");

                entity.HasIndex(e => e.IdRegion)
                    .HasName("Relationship_5_FK");

                entity.HasIndex(e => e.IdStreet)
                    .HasName("Relationship_24_FK");

                entity.HasIndex(e => e.IdTown)
                    .HasName("Relationship_6_FK");

                entity.HasIndex(e => e.IdTypeRegistration)
                    .HasName("Relationship_12_FK");

                entity.Property(e => e.IdRegistration).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdAuthorityNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdAuthority)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_AUTHORIT");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_COUNTRIE");

                entity.HasOne(d => d.IdDistrictNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdDistrict)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_DISTRICT");

                entity.HasOne(d => d.IdHouseNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdHouse)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_HOUSES");

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdPeople)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_peopleDWS");

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdRegion)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_REGIONS");

                entity.HasOne(d => d.IdStreetNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdStreet)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_STREETS");

                entity.HasOne(d => d.IdTownNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdTown)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_TOWNS");

                entity.HasOne(d => d.IdTypeRegistrationNavigation)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.IdTypeRegistration)
                    .HasConstraintName("FK_REGISTRA_RELATIONS_TYPE_REG");
            });

            modelBuilder.Entity<RegistrationType>(entity =>
            {
                entity.Property(e => e.IdTypeRegistration).ValueGeneratedOnAdd();

                entity.Property(e => e.DescriptionRegistration).IsUnicode(false);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.IdStreet).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StreetInfo>(entity =>
            {
                entity.HasIndex(e => e.IdDistrict)
                    .HasName("Relationship_23_FK");

                entity.Property(e => e.IdDw).ValueGeneratedOnAdd();

                entity.Property(e => e.NameStreet).IsUnicode(false);

                entity.HasOne(d => d.IdDistrictNavigation)
                    .WithMany(p => p.StreetInfo)
                    .HasForeignKey(d => d.IdDistrict)
                    .HasConstraintName("FK_STREETS_RELATIONS_DISTRICT");

                entity.HasOne(d => d.IdStreetNavigation)
                    .WithMany(p => p.StreetInfo)
                    .HasForeignKey(d => d.IdStreet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Street_info_StreetR");
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.Property(e => e.IdTown).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TownInfo>(entity =>
            {
                entity.HasIndex(e => e.IdRegion)
                    .HasName("Relationship_9_FK");

                entity.Property(e => e.IdDw).ValueGeneratedOnAdd();

                entity.Property(e => e.NameTown).IsUnicode(false);

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.TownInfo)
                    .HasForeignKey(d => d.IdRegion)
                    .HasConstraintName("FK_TOWNS_RELATIONS_REGIONS");

                entity.HasOne(d => d.IdTownNavigation)
                    .WithMany(p => p.TownInfo)
                    .HasForeignKey(d => d.IdTown)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Town_info_TownR");
            });
        }
    }
}
