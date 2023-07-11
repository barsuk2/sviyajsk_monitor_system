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
    [Migration("20170327123042_TreeRoottypeMigration")]
    partial class TreeRoottypeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
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

                    b.ToTable("accauntReqest");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Analyze", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<int?>("Specimenid");

                    b.Property<string>("UpdatedById");

                    b.Property<DateTime>("date");

                    b.Property<string>("number")
                        .IsRequired();

                    b.Property<int?>("personid");

                    b.Property<int?>("pointid");

                    b.Property<int>("type");

                    b.HasKey("id");

                    b.HasIndex("Specimenid");

                    b.HasIndex("personid");

                    b.HasIndex("pointid");

                    b.ToTable("analyzes");

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

                    b.ToTable("attributekeys");
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

            modelBuilder.Entity("SviyajskMonitorSystem.Models.BuildingElement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<int?>("elementid");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("shifr")
                        .IsRequired();

                    b.Property<int?>("typeid");

                    b.HasKey("id");

                    b.HasIndex("elementid");

                    b.HasIndex("typeid");

                    b.ToTable("BuildingElement");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.BuildingElementType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("BETypes");
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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<int?>("chelementid");

                    b.Property<int?>("rfanalyzeid");

                    b.Property<double>("value");

                    b.HasKey("id");

                    b.HasIndex("chelementid");

                    b.HasIndex("rfanalyzeid");

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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<int?>("dchanalyzeid");

                    b.Property<double>("probability");

                    b.Property<int?>("rcanalyzeid");

                    b.Property<int>("year");

                    b.HasKey("id");

                    b.HasIndex("dchanalyzeid");

                    b.HasIndex("rcanalyzeid");

                    b.ToTable("datings");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DecoreElement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<int?>("elementid");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("elementid");

                    b.ToTable("DecoreElement");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.EntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("types");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.EntityValue", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("typeId");

                    b.Property<string>("value");

                    b.HasKey("id");

                    b.HasIndex("typeId");

                    b.ToTable("values");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.TreeElement", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("identifier");

                    b.Property<int?>("materialobjectid");

                    b.Property<long?>("parentid");

                    b.Property<int?>("typeid");

                    b.HasKey("id");

                    b.HasIndex("materialobjectid");

                    b.HasIndex("parentid");

                    b.HasIndex("typeid");

                    b.ToTable("treeelements");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.TreeRoot", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("elementid");

                    b.Property<long?>("rootid");

                    b.Property<int?>("treetypeid");

                    b.HasKey("id");

                    b.HasIndex("elementid");

                    b.HasIndex("rootid");

                    b.HasIndex("treetypeid");

                    b.ToTable("roots");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Element", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<int?>("culcherobjectid");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<int?>("parentid");

                    b.Property<string>("shifr");

                    b.HasKey("id");

                    b.HasIndex("culcherobjectid");

                    b.HasIndex("parentid");

                    b.ToTable("element");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.HasBactery", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<int?>("bacteryaid");

                    b.Property<int>("celluloznaya");

                    b.Property<long>("count");

                    b.Property<int>("lingnirazr");

                    b.Property<int?>("mbanalyzeid");

                    b.Property<int>("proteznaya");

                    b.HasKey("id");

                    b.HasIndex("bacteryaid");

                    b.HasIndex("mbanalyzeid");

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

                    b.ToTable("organizations");
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

                    b.Property<int?>("DecoreElementid");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<int?>("Sectorid");

                    b.Property<string>("UpdatedById");

                    b.Property<string>("description");

                    b.Property<string>("path");

                    b.Property<int?>("pointid");

                    b.HasKey("id");

                    b.HasIndex("DecoreElementid");

                    b.HasIndex("Sectorid");

                    b.HasIndex("pointid");

                    b.ToTable("photos");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Point", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Organizationid");

                    b.Property<int?>("Personid");

                    b.Property<float>("altitude");

                    b.Property<int?>("buildingElementid");

                    b.Property<int?>("coordinatesid");

                    b.Property<int?>("decoreElementid");

                    b.Property<int?>("directionid");

                    b.Property<int?>("elementid");

                    b.Property<float>("latitude");

                    b.Property<float>("longitude");

                    b.Property<string>("placedescription");

                    b.HasKey("id");

                    b.HasIndex("Organizationid");

                    b.HasIndex("Personid");

                    b.HasIndex("buildingElementid");

                    b.HasIndex("coordinatesid");

                    b.HasIndex("decoreElementid");

                    b.HasIndex("directionid");

                    b.HasIndex("elementid");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Sector", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<string>("UpdatedById");

                    b.Property<int?>("esanalyzeid");

                    b.Property<string>("number");

                    b.HasKey("id");

                    b.HasIndex("esanalyzeid");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Specimen", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Pointid");

                    b.Property<DateTime>("dateofget");

                    b.Property<int?>("organizationid");

                    b.Property<int?>("personid");

                    b.Property<bool>("physical");

                    b.Property<string>("shifr")
                        .IsRequired();

                    b.Property<int?>("storageid");

                    b.HasKey("id");

                    b.HasIndex("Pointid");

                    b.HasIndex("organizationid");

                    b.HasIndex("personid");

                    b.HasIndex("storageid");

                    b.ToTable("specimen");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Storage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("organizationid");

                    b.Property<string>("place")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("organizationid");

                    b.ToTable("storage");
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

                    b.ToTable("treetypes");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Vector3", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("x");

                    b.Property<float>("y");

                    b.Property<float>("z");

                    b.HasKey("id");

                    b.ToTable("Vector3");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.ChooseAttributeValue", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.AbstractAttributeValue");

                    b.Property<int>("itemid");

                    b.Property<string>("listname");

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

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.StringAttributeValue", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.AbstractAttributeValue");


                    b.ToTable("StringAttributeValue");

                    b.HasDiscriminator().HasValue("StringAttributeValue");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DendroChronologicalAnalyze", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.Analyze");

                    b.Property<int?>("codeid");

                    b.Property<int>("roundscount");

                    b.Property<int?>("treeid");

                    b.HasIndex("codeid");

                    b.HasIndex("treeid");

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

                    b.Property<long>("count");

                    b.ToTable("MicroBiologicalAnalyze");

                    b.HasDiscriminator().HasValue("MicroBiologicalAnalyze");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.RadioCarbonAnalyze", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.Analyze");

                    b.Property<int>("error");

                    b.Property<int>("labdatingnumber");

                    b.Property<int>("rcdate");

                    b.ToTable("RadioCarbonAnalyze");

                    b.HasDiscriminator().HasValue("RadioCarbonAnalyze");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.RentgenFluoriscAnalyze", b =>
                {
                    b.HasBaseType("SviyajskMonitorSystem.Models.Analyze");

                    b.Property<int?>("colorid");

                    b.HasIndex("colorid");

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
                    b.HasOne("SviyajskMonitorSystem.Models.Specimen")
                        .WithMany("analyzes")
                        .HasForeignKey("Specimenid");

                    b.HasOne("SviyajskMonitorSystem.Models.Person", "person")
                        .WithMany("analyses")
                        .HasForeignKey("personid");

                    b.HasOne("SviyajskMonitorSystem.Models.Point", "point")
                        .WithMany()
                        .HasForeignKey("pointid");
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

            modelBuilder.Entity("SviyajskMonitorSystem.Models.BuildingElement", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Element", "element")
                        .WithMany()
                        .HasForeignKey("elementid");

                    b.HasOne("SviyajskMonitorSystem.Models.BuildingElementType", "type")
                        .WithMany()
                        .HasForeignKey("typeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.ChemistryElMassDole", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.ChemistryElement", "chelement")
                        .WithMany("massdoles")
                        .HasForeignKey("chelementid");

                    b.HasOne("SviyajskMonitorSystem.Models.RentgenFluoriscAnalyze", "rfanalyze")
                        .WithMany("massdoles")
                        .HasForeignKey("rfanalyzeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Dating", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.DendroChronologicalAnalyze", "dchanalyze")
                        .WithMany("dating")
                        .HasForeignKey("dchanalyzeid");

                    b.HasOne("SviyajskMonitorSystem.Models.RadioCarbonAnalyze", "rcanalyze")
                        .WithMany("dating")
                        .HasForeignKey("rcanalyzeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DecoreElement", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Element", "element")
                        .WithMany()
                        .HasForeignKey("elementid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.EntityValue", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.EntityType", "type")
                        .WithMany("values")
                        .HasForeignKey("typeId");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DynamicFields.TreeElement", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Element", "materialobject")
                        .WithMany()
                        .HasForeignKey("materialobjectid");

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
                        .HasForeignKey("elementid");

                    b.HasOne("SviyajskMonitorSystem.Models.DynamicFields.TreeElement", "root")
                        .WithMany()
                        .HasForeignKey("rootid");

                    b.HasOne("SviyajskMonitorSystem.Models.TreeType", "treetype")
                        .WithMany()
                        .HasForeignKey("treetypeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Element", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.CulcherObject", "culcherobject")
                        .WithMany()
                        .HasForeignKey("culcherobjectid");

                    b.HasOne("SviyajskMonitorSystem.Models.Element", "parent")
                        .WithMany("childs")
                        .HasForeignKey("parentid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.HasBactery", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Bacterya", "bacterya")
                        .WithMany("bacteries")
                        .HasForeignKey("bacteryaid");

                    b.HasOne("SviyajskMonitorSystem.Models.MicroBiologicalAnalyze", "mbanalyze")
                        .WithMany("bacteries")
                        .HasForeignKey("mbanalyzeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Photo", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.DecoreElement")
                        .WithMany("photos")
                        .HasForeignKey("DecoreElementid");

                    b.HasOne("SviyajskMonitorSystem.Models.Sector")
                        .WithMany("photo")
                        .HasForeignKey("Sectorid");

                    b.HasOne("SviyajskMonitorSystem.Models.Point", "point")
                        .WithMany("photos")
                        .HasForeignKey("pointid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Point", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Organization")
                        .WithMany("points")
                        .HasForeignKey("Organizationid");

                    b.HasOne("SviyajskMonitorSystem.Models.Person")
                        .WithMany("points")
                        .HasForeignKey("Personid");

                    b.HasOne("SviyajskMonitorSystem.Models.BuildingElement", "buildingElement")
                        .WithMany()
                        .HasForeignKey("buildingElementid");

                    b.HasOne("SviyajskMonitorSystem.Models.Vector3", "coordinates")
                        .WithMany()
                        .HasForeignKey("coordinatesid");

                    b.HasOne("SviyajskMonitorSystem.Models.DecoreElement", "decoreElement")
                        .WithMany()
                        .HasForeignKey("decoreElementid");

                    b.HasOne("SviyajskMonitorSystem.Models.Vector3", "direction")
                        .WithMany()
                        .HasForeignKey("directionid");

                    b.HasOne("SviyajskMonitorSystem.Models.Element", "element")
                        .WithMany("point")
                        .HasForeignKey("elementid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Sector", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.ElectroMicroScanAnalyze", "esanalyze")
                        .WithMany("sectors")
                        .HasForeignKey("esanalyzeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Specimen", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Point")
                        .WithMany("specimens")
                        .HasForeignKey("Pointid");

                    b.HasOne("SviyajskMonitorSystem.Models.Organization", "organization")
                        .WithMany()
                        .HasForeignKey("organizationid");

                    b.HasOne("SviyajskMonitorSystem.Models.Person", "person")
                        .WithMany()
                        .HasForeignKey("personid");

                    b.HasOne("SviyajskMonitorSystem.Models.Storage", "storage")
                        .WithMany()
                        .HasForeignKey("storageid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.Storage", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Organization", "organization")
                        .WithMany()
                        .HasForeignKey("organizationid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.DendroChronologicalAnalyze", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.ChronoCodes", "code")
                        .WithMany("dchanalyze")
                        .HasForeignKey("codeid");

                    b.HasOne("SviyajskMonitorSystem.Models.Tree", "tree")
                        .WithMany("dchanalyze")
                        .HasForeignKey("treeid");
                });

            modelBuilder.Entity("SviyajskMonitorSystem.Models.RentgenFluoriscAnalyze", b =>
                {
                    b.HasOne("SviyajskMonitorSystem.Models.Color", "color")
                        .WithMany("rfanalyze")
                        .HasForeignKey("colorid");
                });
        }
    }
}
