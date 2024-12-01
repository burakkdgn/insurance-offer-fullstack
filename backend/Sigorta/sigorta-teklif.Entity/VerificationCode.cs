using sigorta_teklif.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigorta_teklif.Entity
{
    public class VerificationCode : BaseEntity
    {
        [Key]
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
