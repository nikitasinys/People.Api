using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace People.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authority",
                columns: table => new
                {
                    Id_authority = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authority", x => x.Id_authority);
                });

            migrationBuilder.CreateTable(
                name: "Authority_type",
                columns: table => new
                {
                    Type_authority = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name_type = table.Column<string>(unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authority_type", x => x.Type_authority);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id_country = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id_country);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id_district = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id_district);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id_house = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id_house);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id_region = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id_region);
                });

            migrationBuilder.CreateTable(
                name: "Registration_type",
                columns: table => new
                {
                    Id_type_registration = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description_registration = table.Column<string>(unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration_type", x => x.Id_type_registration);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    Id_street = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.Id_street);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    Id_town = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.Id_town);
                });

            migrationBuilder.CreateTable(
                name: "Authority_info",
                columns: table => new
                {
                    Id_dw = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_authority = table.Column<int>(nullable: false),
                    Type_authority = table.Column<int>(nullable: true),
                    Name_authority = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true),
                    Relevance_record = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authority_info", x => x.Id_dw);
                    table.ForeignKey(
                        name: "FK_Authority_info_Authority",
                        column: x => x.Id_authority,
                        principalTable: "Authority",
                        principalColumn: "Id_authority",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AUTHORIT_RELATIONS_TYPES_AU",
                        column: x => x.Type_authority,
                        principalTable: "Authority_type",
                        principalColumn: "Type_authority",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country_info",
                columns: table => new
                {
                    Id_dw = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_country = table.Column<int>(nullable: false),
                    Name_country = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true),
                    Relevance_record = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country_info", x => x.Id_dw);
                    table.ForeignKey(
                        name: "FK_Country_info_CountryR",
                        column: x => x.Id_country,
                        principalTable: "Country",
                        principalColumn: "Id_country",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citizenship",
                columns: table => new
                {
                    Id_record_citizenship = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_people = table.Column<long>(nullable: true),
                    Id_country = table.Column<int>(nullable: true),
                    Id_authority = table.Column<int>(nullable: true),
                    Date_issue = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_divorce = table.Column<DateTime>(type: "datetime", nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizenship", x => x.Id_record_citizenship);
                    table.ForeignKey(
                        name: "FK_CITIZENS_RELATIONS_AUTHORIT",
                        column: x => x.Id_authority,
                        principalTable: "Authority",
                        principalColumn: "Id_authority",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CITIZENS_RELATIONS_COUNTRIE",
                        column: x => x.Id_country,
                        principalTable: "Country",
                        principalColumn: "Id_country",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CITIZENS_RELATIONS_peopleDWS",
                        column: x => x.Id_people,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id_family = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_spouse1 = table.Column<long>(nullable: true),
                    Id_spouse2 = table.Column<long>(nullable: true),
                    Id_authority = table.Column<int>(nullable: true),
                    Date_registration = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_divorce = table.Column<DateTime>(type: "datetime", nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id_family);
                    table.ForeignKey(
                        name: "FK_FAMILIES_RELATIONS_AUTHORIT",
                        column: x => x.Id_authority,
                        principalTable: "Authority",
                        principalColumn: "Id_authority",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SPOUSE2_FAMILIES_vs_peopleDWS",
                        column: x => x.Id_spouse1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SPOUSE1_FAMILIES_vs_peopleDWS",
                        column: x => x.Id_spouse2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person_photo",
                columns: table => new
                {
                    Hash_photo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_people = table.Column<long>(nullable: true),
                    Path_to_photo = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Date_photo = table.Column<DateTime>(type: "datetime", nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_photo", x => x.Hash_photo);
                    table.ForeignKey(
                        name: "FK_PHOTOS_P_RELATIONS_peopleDWS",
                        column: x => x.Id_people,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region_info",
                columns: table => new
                {
                    Id_dw = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_region = table.Column<int>(nullable: false),
                    Id_country = table.Column<int>(nullable: true),
                    Name_region = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true),
                    Relevance_record = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region_info", x => x.Id_dw);
                    table.ForeignKey(
                        name: "FK_REGIONS_RELATIONS_COUNTRIE",
                        column: x => x.Id_country,
                        principalTable: "Country",
                        principalColumn: "Id_country",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_info_RegionR",
                        column: x => x.Id_region,
                        principalTable: "Region",
                        principalColumn: "Id_region",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "House_info",
                columns: table => new
                {
                    Id_dw = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_house = table.Column<int>(nullable: false),
                    Id_street = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true),
                    Relevance_record = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House_info", x => x.Id_dw);
                    table.ForeignKey(
                        name: "FK_House_info_HouseR",
                        column: x => x.Id_house,
                        principalTable: "House",
                        principalColumn: "Id_house",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_House_info_Street",
                        column: x => x.Id_street,
                        principalTable: "Street",
                        principalColumn: "Id_street",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Street_info",
                columns: table => new
                {
                    Id_dw = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_street = table.Column<int>(nullable: false),
                    Id_district = table.Column<int>(nullable: true),
                    Name_street = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true),
                    Relevance_record = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street_info", x => x.Id_dw);
                    table.ForeignKey(
                        name: "FK_STREETS_RELATIONS_DISTRICT",
                        column: x => x.Id_district,
                        principalTable: "District",
                        principalColumn: "Id_district",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Street_info_StreetR",
                        column: x => x.Id_street,
                        principalTable: "Street",
                        principalColumn: "Id_street",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District_info",
                columns: table => new
                {
                    Id_dw = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_district = table.Column<int>(nullable: false),
                    Id_town = table.Column<int>(nullable: true),
                    Name_district = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true),
                    Relevance_record = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District_info", x => x.Id_dw);
                    table.ForeignKey(
                        name: "FK_District_info_DistrictR",
                        column: x => x.Id_district,
                        principalTable: "District",
                        principalColumn: "Id_district",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISTRICT_RELATIONS_TOWNS",
                        column: x => x.Id_town,
                        principalTable: "Town",
                        principalColumn: "Id_town",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person_info",
                columns: table => new
                {
                    Id_people = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Patronymic = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Id_country_birthday = table.Column<int>(nullable: true),
                    Id_region_birthday = table.Column<int>(nullable: true),
                    Id_town_birthday = table.Column<int>(nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Date_birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_death = table.Column<DateTime>(type: "datetime", nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_info", x => x.Id_people);
                    table.ForeignKey(
                        name: "FK_peopleDWS_RELATIONS_COUNTRIE",
                        column: x => x.Id_country_birthday,
                        principalTable: "Country",
                        principalColumn: "Id_country",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_info_People",
                        column: x => x.Id_people,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_peopleDWS_RELATIONS_REGIONS",
                        column: x => x.Id_region_birthday,
                        principalTable: "Region",
                        principalColumn: "Id_region",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_peopleDWS_RELATIONS_TOWNS",
                        column: x => x.Id_town_birthday,
                        principalTable: "Town",
                        principalColumn: "Id_town",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id_registration = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_people = table.Column<long>(nullable: true),
                    Id_country = table.Column<int>(nullable: true),
                    Id_region = table.Column<int>(nullable: true),
                    Id_town = table.Column<int>(nullable: true),
                    Id_district = table.Column<int>(nullable: true),
                    Id_street = table.Column<int>(nullable: true),
                    Id_house = table.Column<int>(nullable: true),
                    Num_housing = table.Column<int>(nullable: true),
                    Num_flat = table.Column<int>(nullable: true),
                    Id_type_registration = table.Column<int>(nullable: true),
                    Id_authority = table.Column<int>(nullable: true),
                    Date_issue = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_termination = table.Column<DateTime>(type: "datetime", nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id_registration);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_AUTHORIT",
                        column: x => x.Id_authority,
                        principalTable: "Authority",
                        principalColumn: "Id_authority",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_COUNTRIE",
                        column: x => x.Id_country,
                        principalTable: "Country",
                        principalColumn: "Id_country",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_DISTRICT",
                        column: x => x.Id_district,
                        principalTable: "District",
                        principalColumn: "Id_district",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_HOUSES",
                        column: x => x.Id_house,
                        principalTable: "House",
                        principalColumn: "Id_house",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_peopleDWS",
                        column: x => x.Id_people,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_REGIONS",
                        column: x => x.Id_region,
                        principalTable: "Region",
                        principalColumn: "Id_region",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_STREETS",
                        column: x => x.Id_street,
                        principalTable: "Street",
                        principalColumn: "Id_street",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_TOWNS",
                        column: x => x.Id_town,
                        principalTable: "Town",
                        principalColumn: "Id_town",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTRA_RELATIONS_TYPE_REG",
                        column: x => x.Id_type_registration,
                        principalTable: "Registration_type",
                        principalColumn: "Id_type_registration",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Town_info",
                columns: table => new
                {
                    Id_dw = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_town = table.Column<int>(nullable: false),
                    Id_region = table.Column<int>(nullable: true),
                    Name_town = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    Datetime_added = table.Column<DateTime>(type: "datetime", nullable: true),
                    Relevance_record = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town_info", x => x.Id_dw);
                    table.ForeignKey(
                        name: "FK_TOWNS_RELATIONS_REGIONS",
                        column: x => x.Id_region,
                        principalTable: "Region",
                        principalColumn: "Id_region",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Town_info_TownR",
                        column: x => x.Id_town,
                        principalTable: "Town",
                        principalColumn: "Id_town",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authority_info_Id_authority",
                table: "Authority_info",
                column: "Id_authority");

            migrationBuilder.CreateIndex(
                name: "Relationship_11_FK",
                table: "Authority_info",
                column: "Type_authority");

            migrationBuilder.CreateIndex(
                name: "Relationship_13_FK",
                table: "Citizenship",
                column: "Id_authority");

            migrationBuilder.CreateIndex(
                name: "Relationship_16_FK",
                table: "Citizenship",
                column: "Id_country");

            migrationBuilder.CreateIndex(
                name: "Relationship_17_FK",
                table: "Citizenship",
                column: "Id_people");

            migrationBuilder.CreateIndex(
                name: "IX_Country_info_Id_country",
                table: "Country_info",
                column: "Id_country");

            migrationBuilder.CreateIndex(
                name: "IX_District_info_Id_district",
                table: "District_info",
                column: "Id_district");

            migrationBuilder.CreateIndex(
                name: "Relationship_10_FK",
                table: "District_info",
                column: "Id_town");

            migrationBuilder.CreateIndex(
                name: "Relationship_15_FK",
                table: "Family",
                column: "Id_authority");

            migrationBuilder.CreateIndex(
                name: "Relationship_2_FK",
                table: "Family",
                column: "Id_spouse1");

            migrationBuilder.CreateIndex(
                name: "Relationship_3_FK",
                table: "Family",
                column: "Id_spouse2");

            migrationBuilder.CreateIndex(
                name: "IX_House_info_Id_house",
                table: "House_info",
                column: "Id_house");

            migrationBuilder.CreateIndex(
                name: "Relationship_22_FK",
                table: "House_info",
                column: "Id_street");

            migrationBuilder.CreateIndex(
                name: "Relationship_19_FK",
                table: "Person_info",
                column: "Id_country_birthday");

            migrationBuilder.CreateIndex(
                name: "Relationship_20_FK",
                table: "Person_info",
                column: "Id_region_birthday");

            migrationBuilder.CreateIndex(
                name: "Relationship_21_FK",
                table: "Person_info",
                column: "Id_town_birthday");

            migrationBuilder.CreateIndex(
                name: "Relationship_1_FK",
                table: "Person_photo",
                column: "Id_people");

            migrationBuilder.CreateIndex(
                name: "Relationship_8_FK",
                table: "Region_info",
                column: "Id_country");

            migrationBuilder.CreateIndex(
                name: "IX_Region_info_Id_region",
                table: "Region_info",
                column: "Id_region");

            migrationBuilder.CreateIndex(
                name: "Relationship_14_FK",
                table: "Registration",
                column: "Id_authority");

            migrationBuilder.CreateIndex(
                name: "Relationship_4_FK",
                table: "Registration",
                column: "Id_country");

            migrationBuilder.CreateIndex(
                name: "Relationship_7_FK",
                table: "Registration",
                column: "Id_district");

            migrationBuilder.CreateIndex(
                name: "Relationship_25_FK",
                table: "Registration",
                column: "Id_house");

            migrationBuilder.CreateIndex(
                name: "Relationship_18_FK",
                table: "Registration",
                column: "Id_people");

            migrationBuilder.CreateIndex(
                name: "Relationship_5_FK",
                table: "Registration",
                column: "Id_region");

            migrationBuilder.CreateIndex(
                name: "Relationship_24_FK",
                table: "Registration",
                column: "Id_street");

            migrationBuilder.CreateIndex(
                name: "Relationship_6_FK",
                table: "Registration",
                column: "Id_town");

            migrationBuilder.CreateIndex(
                name: "Relationship_12_FK",
                table: "Registration",
                column: "Id_type_registration");

            migrationBuilder.CreateIndex(
                name: "Relationship_23_FK",
                table: "Street_info",
                column: "Id_district");

            migrationBuilder.CreateIndex(
                name: "IX_Street_info_Id_street",
                table: "Street_info",
                column: "Id_street");

            migrationBuilder.CreateIndex(
                name: "Relationship_9_FK",
                table: "Town_info",
                column: "Id_region");

            migrationBuilder.CreateIndex(
                name: "IX_Town_info_Id_town",
                table: "Town_info",
                column: "Id_town");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authority_info");

            migrationBuilder.DropTable(
                name: "Citizenship");

            migrationBuilder.DropTable(
                name: "Country_info");

            migrationBuilder.DropTable(
                name: "District_info");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropTable(
                name: "House_info");

            migrationBuilder.DropTable(
                name: "Person_info");

            migrationBuilder.DropTable(
                name: "Person_photo");

            migrationBuilder.DropTable(
                name: "Region_info");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Street_info");

            migrationBuilder.DropTable(
                name: "Town_info");

            migrationBuilder.DropTable(
                name: "Authority_type");

            migrationBuilder.DropTable(
                name: "Authority");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Registration_type");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Town");
        }
    }
}
