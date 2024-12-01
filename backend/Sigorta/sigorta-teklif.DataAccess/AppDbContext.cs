using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sigorta_teklif.Entity;

namespace sigorta_teklif.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        // DbSet tanımları
        public DbSet<SigortaPolicy> SigortaPolicies { get; set; } // Entity ekledik
        public DbSet<Applicant> Applicants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Sigortali ile ilişkiyi yapılandırma
            modelBuilder.Entity<SigortaPolicy>()
                .HasOne(p => p.Sigortali)
                .WithMany(a => a.SigortalıPolicies)
                .HasForeignKey(p => p.SigortaliID)
                .OnDelete(DeleteBehavior.Restrict);

            // SigortaEttiren ile ilişkiyi yapılandırma
            modelBuilder.Entity<SigortaPolicy>()
                .HasOne(p => p.SigortaEttiren)
                .WithMany(a => a.SigortaEttirenPolicies)
                .HasForeignKey(p => p.SigortaEttirenID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
