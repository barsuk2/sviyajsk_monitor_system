using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Models.DynamicFields;
namespace SviyajskMonitorSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Analyze> Analyzes { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Point> Point { get; set; }
        public DbSet<Vector3> Vector3 { get; set; }
        public DbSet<Bacterya> Bacterya { get; set; }
        public DbSet<Dating> Datings { get; set; }
        public DbSet<HasBactery> HasBactery { get; set; }
        public DbSet<MicroBiologicalAnalyze> MBAnalyzes { get; set; }
        public DbSet<DendroChronologicalAnalyze> DCrAnalyzes { get; set; }
        public DbSet<ElectroMicroScanAnalyze> ElMsAnalyze { get; set; }
        public DbSet<RadioCarbonAnalyze> RCAnalyze { get; set; }
        public DbSet<RentgenFluoriscAnalyze> RFlAnalyze { get; set; }
        public DbSet<Tree> Tree { get; set; }
        public DbSet<ChemistryElement> ChemistryElement { get; set; }
        public DbSet<ChemistryElMassDole> ChemistryElMassDole { get; set; }
        public DbSet<ChronoCodes> ChronoCodes { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<CulcherObject> CulcherObject { get; set; }
        public DbSet<Element> Element { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<AccauntRequestData> AccauntReqest { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<AttributeKey> Attributekeys { get; set; }
        public DbSet<TreeElement> Treeelements { get; set; }
        public DbSet<TreeType> Treetypes { get; set; }
        public DbSet<IntAttributeValue> Intvalues { get; set; }
        public DbSet<FloatAttributeValue> Floatvalues { get; set; }
        public DbSet<StringAttributeValue> Stringvalues { get; set; }
        public DbSet<ChooseAttributeValue> Chooseattribute { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<EntityType> Types { get; set; }
        public DbSet<EntityValue> Values { get; set; }
        public DbSet<TreeRoot> Roots { get; set; }
        public DbSet<PhotoAttributeValue> Photosattribute { get; set; }
        public DbSet<_3DModel> Models{get;set;}
        public DbSet<Region> Regions { get; set; }
        public DbSet<UnityPoint> UnityPoints { get; set; }
        public DbSet<ElementsAttributeValue> ElementsAttribute { get; set; }
    }
}
