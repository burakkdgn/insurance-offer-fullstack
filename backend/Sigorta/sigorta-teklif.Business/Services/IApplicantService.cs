using sigorta_teklif.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigorta_teklif.Business.Services
{
    public interface IApplicantService
    {
        Task<List<Applicant>> GetAllApplicantsAsync();
        Task<Applicant> GetApplicantByIdAsync(int id);
        Task<Applicant> AddApplicantAsync(Applicant applicant);
        Task<Applicant> UpdateApplicantAsync(Applicant applicant);
        Task<bool> DeleteApplicantAsync(int id);
    }
}
