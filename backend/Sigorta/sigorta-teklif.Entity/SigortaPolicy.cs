using sigorta_teklif.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigorta_teklif.Entity
{
    public class SigortaPolicy : BaseEntity
    {
        [Key]
        public int PolicyID { get; set; }
        public int SigortaliID { get; set; }
        public virtual Applicant Sigortali { get; set; }
        public int SigortaEttirenID { get; set; }
        public virtual Applicant SigortaEttiren { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool Offer { get; set; }
    }
}
