
using Microsoft.EntityFrameworkCore;
using sigorta_teklif.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigorta_teklif.DataAccess
{
    public class SigortaPolicyRepository : GenericRepository<SigortaPolicy>, ISigortaPolicyRepository
    {
        public SigortaPolicyRepository(AppDbContext context) : base(context)
        {

        }
    }
}
