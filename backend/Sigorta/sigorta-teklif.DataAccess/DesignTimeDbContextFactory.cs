using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace sigorta_teklif.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=IAGUY67;Database=SigortaTeklifDb;Trusted_Connection=True;User Id=zeynep.gungor;Password=Kartal6003.;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}