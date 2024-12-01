using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sigorta_teklif.Entity;

namespace sigorta_teklif.Business.Services
{
    public interface ISigortaService
    {
        Task<List<SigortaPolicy>> GetAllPoliciesAsync();
        Task<SigortaPolicy> GetPolicyByIdAsync(int id);
        Task<SigortaPolicy> CreatePolicyAsync(SigortaPolicy policy);
        Task<SigortaPolicy> UpdatePolicyAsync(SigortaPolicy policy);
        Task<bool> DeletePolicyAsync(int id);
    }
}
