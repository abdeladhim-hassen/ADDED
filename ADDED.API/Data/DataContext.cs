using ADDED.API.Models;
using ADDED.API.SonedeModels;
using Microsoft.EntityFrameworkCore;

namespace ADDED.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Anomalie> Anomalies { get; set; }
        public DbSet<ChoixPlan> ChoixPlans { get; set; }
        public DbSet<Compteur> Compteurs { get; set; }
        public DbSet<Creation> Creations { get; set; }
        public DbSet<Detaille> Detailles { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Historique> Historiques { get; set; }
        public DbSet<Index> Indexs { get; set; }
        public DbSet<ListAnomalie> ListAnomalies { get; set; }
        public DbSet<Localite> Localites { get; set; }
        public DbSet<Portable> Portables { get; set; }
        public DbSet<Releveur> Releveurs { get; set; }
        public DbSet<Tournee> Tournees { get; set; }
        public DbSet<Chef> ChefBureau { get; set; }
        public DbSet<Base20231> Base20231 { get; set; }
        public DbSet<Basecptr> Basecptr { get; set; }
        public DbSet<Histo1> Histo1 { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Base20231>()
                .HasKey(b => new { b.Dist, b.Tou, b.Ord });
            builder.Entity<Basecptr>()
                .HasKey(b => new { b.Dist, b.Tou, b.Ord });
            builder.Entity<Histo1>()
                .HasKey(b => new { b.Zdis, b.Ztou, b.Zord, b.Ztrim, b.Zanne });
        }
        
    }
}
