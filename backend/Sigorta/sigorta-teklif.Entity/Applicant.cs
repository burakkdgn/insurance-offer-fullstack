using sigorta_teklif.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigorta_teklif.Entity
{
    public class Applicant : BaseEntity
    {
        [Key]
        public int ApplicantID { get; set; }
        public string TC { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public virtual ICollection<SigortaPolicy> SigortalıPolicies { get; set; }
        public virtual ICollection<SigortaPolicy> SigortaEttirenPolicies { get; set; }
        
    }
}
