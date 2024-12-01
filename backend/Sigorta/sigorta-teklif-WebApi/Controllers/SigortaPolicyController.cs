using Microsoft.AspNetCore.Mvc;
using sigorta_teklif.Business.Services;
using sigorta_teklif.Entity;
using sigorta_teklif.DTO;

namespace sigorta_teklif.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigortaPolicyController : ControllerBase
    {
        private readonly ISigortaService _sigortaService;

        public SigortaPolicyController(ISigortaService sigortaService)
        {
            _sigortaService = sigortaService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sigortaService.GetAllPoliciesAsync();
            if (result != null && result.Any())
            {
                return Ok(new { Data = result, Message = "Tüm poliçeler başarıyla getirildi." });
            }
            return NotFound("Hiçbir poliçe bulunamadı.");
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _sigortaService.GetPolicyByIdAsync(id);
            if (result != null)
            {
                return Ok(new { Data = result, Message = "Poliçe başarıyla getirildi." });
            }
            return NotFound("Poliçe bulunamadı.");
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SigortaPolicyDTO policyDto)
        {
            var newPolicy = new SigortaPolicy
            {
                PolicyID = policyDto.PolicyID,
                SigortaliID = policyDto.ApplicantID,
                SigortaEttirenID = policyDto.SigortacıID,
                StartDate = policyDto.StartDate,
                EndDate = policyDto.EndDate,
                Price = policyDto.Price,
                Offer = policyDto.Offer
            };

            var result = await _sigortaService.CreatePolicyAsync(newPolicy);
            if (result != null)
            {
                return Ok(new { Data = result, Message = "Poliçe başarıyla eklendi." });
            }
            return BadRequest("Poliçe eklenirken bir hata oluştu.");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, SigortaPolicyDTO policyDto)
        {
            if (id != policyDto.PolicyID)
            {
                return BadRequest("Poliçe ID'leri eşleşmiyor.");
            }

            var updatedPolicy = new SigortaPolicy
            {
                PolicyID = policyDto.PolicyID,
                SigortaliID = policyDto.ApplicantID,
                SigortaEttirenID = policyDto.SigortacıID,
                StartDate = policyDto.StartDate,
                EndDate = policyDto.EndDate,
                Price = policyDto.Price,
                Offer = policyDto.Offer
            };

            var result = await _sigortaService.UpdatePolicyAsync(updatedPolicy);
            if (result != null)
            {
                return Ok(new { Data = result, Message = "Poliçe başarıyla güncellendi." });
            }
            return BadRequest("Poliçe güncellenirken bir hata oluştu.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPolicy = await _sigortaService.GetPolicyByIdAsync(id);
            if (existingPolicy == null)
            {
                return NotFound("Silinecek poliçe bulunamadı.");
            }

            var result = await _sigortaService.DeletePolicyAsync(id);
            if (result)
            {
                return Ok(new { Message = "Poliçe başarıyla silindi." });
            }
            return BadRequest("Poliçe silinirken bir hata oluştu.");
        }
    }
}
