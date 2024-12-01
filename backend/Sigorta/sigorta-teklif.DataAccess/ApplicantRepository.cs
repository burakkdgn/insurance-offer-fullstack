﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sigorta_teklif.Core;
using sigorta_teklif.Entity;

namespace sigorta_teklif.DataAccess
{
    public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(AppDbContext context) : base(context)
        {
        }
    }
}