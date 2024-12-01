using sigorta_teklif.Business.Services;
using sigorta_teklif.Core;
using sigorta_teklif.DataAccess;
using sigorta_teklif.Entity;


namespace sigorta_teklif.Business.Managers
{
    public class SigortaManager : ISigortaService
    {
        private readonly ISigortaPolicyRepository _repository;

        public SigortaManager(ISigortaPolicyRepository repository)
        {
            _repository = repository;
        }

        public Task<SigortaPolicy> CreatePolicyAsync(SigortaPolicy policy)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePolicyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SigortaPolicy>> GetAllPoliciesAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }

        public Task<SigortaPolicy> GetPolicyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SigortaPolicy> UpdatePolicyAsync(SigortaPolicy policy)
        {
            throw new NotImplementedException();
        }
    }
}
