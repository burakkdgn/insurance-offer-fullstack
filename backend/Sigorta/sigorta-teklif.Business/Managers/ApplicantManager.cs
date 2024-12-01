using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sigorta_teklif.Business.Services;
using sigorta_teklif.Core;
using sigorta_teklif.Entity;
using sigorta_teklif.DataAccess;

namespace sigorta_teklif.Business.Managers
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _repository;

        public ApplicantManager(IApplicantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Applicant> AddApplicantAsync(Applicant applicant)
        {
            await _repository.AddAsync(applicant);
            return applicant;
        }

        public async Task<bool> DeleteApplicantAsync(int id)
        {
            var applicant = await _repository.GetByIdAsync(id);
            if (applicant == null)
                return false;

            _repository.Remove(applicant);
            return true;
        }

        public async Task<List<Applicant>> GetAllApplicantsAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }

        public async Task<Applicant> GetApplicantByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Applicant> UpdateApplicantAsync(Applicant applicant)
        {
            _repository.Update(applicant);
            return applicant;
        }
    }
}
