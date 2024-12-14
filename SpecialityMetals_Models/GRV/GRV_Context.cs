using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.GRV
{
    public class GRVDbContext : DbContext
    {
        public GRVDbContext(DbContextOptions<GRVDbContext> options) : base(options) { }
        public DbSet<GRVS> GRVs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GRVS>()
                .ToTable("GRV");
        }
    }
}
