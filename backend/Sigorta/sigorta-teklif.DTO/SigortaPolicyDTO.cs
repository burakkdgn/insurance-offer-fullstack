using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigorta_teklif.DTO
{
    public class SigortaPolicyDTO
    {
        public int PolicyID { get; set; }
        public int ApplicantID { get; set; }
        public int SigortacıID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool Offer { get; set; }
    }
}
