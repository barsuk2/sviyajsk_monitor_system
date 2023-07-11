using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;

namespace SviyajskMonitorSystem.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170703134350_ModelFixesMigration")]
    partial class ModelFixesMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models._3DModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("ElementId");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.AbstractAttributeValue", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long?>("TreeElementid");

                    b.Property<int?>("attributekeyid");

                    b.HasKey("id");

                    b.HasIndex("TreeElementid");

                    b.HasIndex("attributekeyid");

                    b.ToTable("AbstractAttributeValue");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractAttributeValue");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.AccauntRequestData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("phone")
                        .IsRequired();

                    b.Property<string>("surname")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("AccauntReqest");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Analyze", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<int?>("Personid");

                    b.Property<int?>("SampleId");

                    b.Property<int>("Type");

                    b.Property<string>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("Personid");

                    b.HasIndex("SampleId");

                    b.ToTable("Analyzes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Analyze");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("name");

                    b.Property<string>("surname");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.AttributeKey", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TreeTypeid");

                    b.Property<int?>("entitytypeId");

                    b.Property<string>("name");

                    b.Property<int>("type");

                    b.HasKey("id");

                    b.HasIndex("TreeTypeid");

                    b.HasIndex("entitytypeId");

                    b.ToTable("Attributekeys");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Bacterya", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("rodname");

                    b.Property<string>("vidname");

                    b.HasKey("id");

                    b.ToTable("Bacterya");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.ChemistryElement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("fullname")
                        .IsRequired();

                    b.Property<string>("shortname")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("ChemistryElement");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.ChemistryElMassDole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Chelementid");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<int?>("RentgenFluoriscAnalyzeId");

                    b.Property<int?>("SectorId");

                    b.Property<string>("UpdatedById");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("Chelementid");

                    b.HasIndex("RentgenFluoriscAnalyzeId");

                    b.HasIndex("SectorId");

                    b.ToTable("ChemistryElMassDole");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.ChronoCodes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.HasKey("id");

                    b.ToTable("ChronoCodes");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Color", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.CulcherObject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("bandlepath");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("CulcherObject");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Dating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<int>("DateFrom");

                    b.Property<int>("DateTo");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<double>("Probability");

                    b.Property<int?>("RcanalyzeId");

                    b.Property<string>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("RcanalyzeId");

                    b.ToTable("Datings");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.EntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.EntityValue", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("typeId");

                    b.Property<string>("value");

                    b.HasKey("id");

                    b.HasIndex("typeId");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.TreeElement", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PointId");

                    b.Property<string>("identifier");

                    b.Property<int?>("materialobjectId");

                    b.Property<long?>("parentid");

                    b.Property<int?>("typeid");

                    b.HasKey("id");

                    b.HasIndex("PointId");

                    b.HasIndex("materialobjectId");

                    b.HasIndex("parentid");

                    b.HasIndex("typeid");

                    b.ToTable("Treeelements");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.TreeRoot", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("elementId");

                    b.Property<long?>("rootid");

                    b.Property<int?>("treetypeid");

                    b.HasKey("id");

                    b.HasIndex("elementId");

                    b.HasIndex("rootid");

                    b.HasIndex("treetypeid");

                    b.ToTable("Roots");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ParentId");

                    b.Property<string>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Element");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.HasBactery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Bacteryaid");

                    b.Property<long>("Count");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<int?>("MbanalyzeId");

                    b.Property<string>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("Bacteryaid");

                    b.HasIndex("MbanalyzeId");

                    b.ToTable("HasBactery");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Organization", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("surname")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Photo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<long?>("PhotoAttributeValueid");

                    b.Property<int?>("RegionId");

                    b.Property<int?>("SectorId");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("description");

                    b.Property<string>("path");

                    b.Property<int?>("pointId");

                    b.HasKey("id");

                    b.HasIndex("PhotoAttributeValueid");

                    b.HasIndex("RegionId");

                    b.HasIndex("SectorId");

                    b.HasIndex("pointId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Altitude");

                    b.Property<int?>("ElementId");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<int?>("Organizationid");

                    b.Property<int?>("Personid");

                    b.Property<string>("Placedescription");

                    b.Property<int?>("UnitypointId");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.HasIndex("Organizationid");

                    b.HasIndex("Personid");

                    b.HasIndex("UnitypointId");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ElectroMicroScanAnalyzeId");

                    b.HasKey("Id");

                    b.HasIndex("ElectroMicroScanAnalyzeId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Colorid");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("Number");

                    b.Property<int?>("RegionId");

                    b.Property<string>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("Colorid");

                    b.HasIndex("RegionId");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Specimen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Dateofget");

                    b.Property<int?>("Personid");

                    b.Property<bool>("Physical");

                    b.Property<int?>("PointId");

                    b.Property<string>("Shifr")
                        .IsRequired();

                    b.Property<int?>("StorageId");

                    b.HasKey("Id");

                    b.HasIndex("Personid");

                    b.HasIndex("PointId");

                    b.HasIndex("StorageId");

                    b.ToTable("Specimen");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Organizationid");

                    b.Property<string>("Place")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Organizationid");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Tree", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Tree");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.TreeType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Treetypes");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.UnityPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DirectionId");

                    b.Property<int?>("ModelId");

                    b.Property<int?>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("DirectionId");

                    b.HasIndex("ModelId");

                    b.HasIndex("PositionId");

                    b.ToTable("UnityPoints");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Vector3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("X");

                    b.Property<float>("Y");

                    b.Property<float>("Z");

                    b.HasKey("Id");

                    b.ToTable("Vector3");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.ChooseAttributeValue", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.AbstractAttributeValue");

                    b.Property<int?>("valueid");

                    b.HasIndex("valueid");

                    b.ToTable("ChooseAttributeValue");

                    b.HasDiscriminator().HasValue("ChooseAttributeValue");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.FloatAttributeValue", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.AbstractAttributeValue");

                    b.Property<float>("floatvalue");

                    b.ToTable("FloatAttributeValue");

                    b.HasDiscriminator().HasValue("FloatAttributeValue");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.IntAttributeValue", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.AbstractAttributeValue");

                    b.Property<int>("intvalue");

                    b.ToTable("IntAttributeValue");

                    b.HasDiscriminator().HasValue("IntAttributeValue");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.PhotoAttributeValue", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.AbstractAttributeValue");


                    b.ToTable("PhotoAttributeValue");

                    b.HasDiscriminator().HasValue("PhotoAttributeValue");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.StringAttributeValue", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.AbstractAttributeValue");

                    b.Property<string>("stringvalue");

                    b.ToTable("StringAttributeValue");

                    b.HasDiscriminator().HasValue("StringAttributeValue");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DendroChronologicalAnalyze", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.Analyze");

                    b.Property<int?>("Codeid");

                    b.Property<int>("DateFrom");

                    b.Property<int>("DateTo");

                    b.Property<int>("Roundscount");

                    b.Property<int?>("Treeid");

                    b.HasIndex("Codeid");

                    b.HasIndex("Treeid");

                    b.ToTable("DendroChronologicalAnalyze");

                    b.HasDiscriminator().HasValue("DendroChronologicalAnalyze");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.ElectroMicroScanAnalyze", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.Analyze");


                    b.ToTable("ElectroMicroScanAnalyze");

                    b.HasDiscriminator().HasValue("ElectroMicroScanAnalyze");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.MicroBiologicalAnalyze", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.Analyze");

                    b.Property<int>("Celluloznaya");

                    b.Property<long>("Count");

                    b.Property<int>("Lingnirazr");

                    b.Property<int>("Proteznaya");

                    b.ToTable("MicroBiologicalAnalyze");

                    b.HasDiscriminator().HasValue("MicroBiologicalAnalyze");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.RadioCarbonAnalyze", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.Analyze");

                    b.Property<float>("Error");

                    b.Property<int>("Labdatingnumber");

                    b.Property<int>("Rcdate");

                    b.Property<int?>("TreeTypeid");

                    b.HasIndex("TreeTypeid");

                    b.ToTable("RadioCarbonAnalyze");

                    b.HasDiscriminator().HasValue("RadioCarbonAnalyze");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.RentgenFluoriscAnalyze", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.Analyze");

                    b.Property<int?>("Colorid");

                    b.HasIndex("Colorid");

                    b.ToTable("RentgenFluoriscAnalyze");

                    b.HasDiscriminator().HasValue("RentgenFluoriscAnalyze");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SviyajskMonitorSystem.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models._3DModel", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Element", "Element")
                        .WithMany("Models")
                        .HasForeignKey("ElementId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.AbstractAttributeValue", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.TreeElement")
                        .WithMany("values")
                        .HasForeignKey("TreeElementid");

                    b.HasOne("SviyajskMonitorSystem.Models.AttributeKey", "attributekey")
                        .WithMany()
                        .HasForeignKey("attributekeyid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Analyze", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Person", "Person")
                        .WithMany("analyses")
                        .HasForeignKey("Personid");

                    b.HasOne("SviyajskMonitorSystem.Models.Specimen", "Sample")
                        .WithMany("Analyzes")
                        .HasForeignKey("SampleId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.AttributeKey", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.TreeType")
                        .WithMany("keys")
                        .HasForeignKey("TreeTypeid");

                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.EntityType", "entitytype")
                        .WithMany()
                        .HasForeignKey("entitytypeId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.ChemistryElMassDole", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.ChemistryElement", "Chelement")
                        .WithMany("massdoles")
                        .HasForeignKey("Chelementid");

                    b.HasOne("SviyajskMonitorSystem.Models.RentgenFluoriscAnalyze")
                        .WithMany("Massdoles")
                        .HasForeignKey("RentgenFluoriscAnalyzeId");

                    b.HasOne("SviyajskMonitorSystem.Models.Sector")
                        .WithMany("Massdoles")
                        .HasForeignKey("SectorId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Dating", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.RadioCarbonAnalyze", "Rcanalyze")
                        .WithMany("Datings")
                        .HasForeignKey("RcanalyzeId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.EntityValue", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.EntityType", "type")
                        .WithMany("values")
                        .HasForeignKey("typeId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.TreeElement", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Point")
                        .WithMany("Treeelements")
                        .HasForeignKey("PointId");

                    b.HasOne("SviyajskMonitorSystem.Models.Element", "materialobject")
                        .WithMany()
                        .HasForeignKey("materialobjectId");

                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.TreeElement", "parent")
                        .WithMany("children")
                        .HasForeignKey("parentid");

                    b.HasOne("SviyajskMonitorSystem.Models.TreeType", "type")
                        .WithMany()
                        .HasForeignKey("typeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.TreeRoot", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Element", "element")
                        .WithMany()
                        .HasForeignKey("elementId");

                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.TreeElement", "root")
                        .WithMany()
                        .HasForeignKey("rootid");

                    b.HasOne("SviyajskMonitorSystem.Models.TreeType", "treetype")
                        .WithMany()
                        .HasForeignKey("treetypeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Element", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Element", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.HasBactery", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Bacterya", "Bacterya")
                        .WithMany("bacteries")
                        .HasForeignKey("Bacteryaid");

                    b.HasOne("SviyajskMonitorSystem.Models.MicroBiologicalAnalyze", "Mbanalyze")
                        .WithMany("Bacteries")
                        .HasForeignKey("MbanalyzeId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Photo", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.PhotoAttributeValue")
                        .WithMany("photos")
                        .HasForeignKey("PhotoAttributeValueid");

                    b.HasOne("SviyajskMonitorSystem.Models.Region")
                        .WithMany("Photos")
                        .HasForeignKey("RegionId");

                    b.HasOne("SviyajskMonitorSystem.Models.Sector")
                        .WithMany("Photos")
                        .HasForeignKey("SectorId");

                    b.HasOne("SviyajskMonitorSystem.Models.Point", "point")
                        .WithMany("Photos")
                        .HasForeignKey("pointId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Point", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Element", "Element")
                        .WithMany("Point")
                        .HasForeignKey("ElementId");

                    b.HasOne("SviyajskMonitorSystem.Models.Organization")
                        .WithMany("points")
                        .HasForeignKey("Organizationid");

                    b.HasOne("SviyajskMonitorSystem.Models.Person")
                        .WithMany("points")
                        .HasForeignKey("Personid");

                    b.HasOne("SviyajskMonitorSystem.Models.UnityPoint", "Unitypoint")
                        .WithMany()
                        .HasForeignKey("UnitypointId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Region", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.ElectroMicroScanAnalyze")
                        .WithMany("Regions")
                        .HasForeignKey("ElectroMicroScanAnalyzeId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Sector", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("Colorid");

                    b.HasOne("SviyajskMonitorSystem.Models.Region", "Region")
                        .WithMany("Sectors")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Specimen", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("Personid");

                    b.HasOne("SviyajskMonitorSystem.Models.Point")
                        .WithMany("Specimens")
                        .HasForeignKey("PointId");

                    b.HasOne("SviyajskMonitorSystem.Models.Storage", "Storage")
                        .WithMany()
                        .HasForeignKey("StorageId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Storage", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("Organizationid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.UnityPoint", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Vector3", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId");

                    b.HasOne("SviyajskMonitorSystem.Models._3DModel", "Model")
                        .WithMany("Unitypoints")
                        .HasForeignKey("ModelId");

                    b.HasOne("SviyajskMonitorSystem.Models.Vector3", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.ChooseAttributeValue", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.EntityValue", "value")
                        .WithMany()
                        .HasForeignKey("valueid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DendroChronologicalAnalyze", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.ChronoCodes", "Code")
                        .WithMany("dchanalyze")
                        .HasForeignKey("Codeid");

                    b.HasOne("SviyajskMonitorSystem.Models.Tree", "Tree")
                        .WithMany("dchanalyze")
                        .HasForeignKey("Treeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.RadioCarbonAnalyze", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Tree", "TreeType")
                        .WithMany()
                        .HasForeignKey("TreeTypeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.RentgenFluoriscAnalyze", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Color", "Color")
                        .WithMany("rfanalyze")
                        .HasForeignKey("Colorid");
                });
        }
    }
}
