﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigorta_teklif.DTO
{
    public class UpdateApplicantDTO
    {
        public int ApplicantID { get; set; }
        public string TC { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
    }
}