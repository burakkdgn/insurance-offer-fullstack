using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sigorta_teklif.Business.Services;
using sigorta_teklif.DTO;
using sigorta_teklif.Entity;

namespace sigorta_teklif.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var applicants = await _applicantService.GetAllApplicantsAsync();
            return Ok(new { Data = applicants, Message = "Başarılı" });
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var applicant = await _applicantService.GetApplicantByIdAsync(id);
            if (applicant == null)
                return NotFound("Başvuru sahibi bulunamadı.");
            return Ok(applicant);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddApplicantDTO dto)
        {
            var applicant = new Applicant
            {
                TC = dto.TC,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                Number = dto.Number
            };

            var result = await _applicantService.AddApplicantAsync(applicant);
            return CreatedAtAction(nameof(GetById), new { id = result.ApplicantID }, result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateApplicantDTO dto)
        {
            if (id != dto.ApplicantID)
                return BadRequest("ID'ler uyuşmuyor.");

            var applicant = new Applicant
            {
                ApplicantID = dto.ApplicantID,
                TC = dto.TC,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                Number = dto.Number
            };

            var result = await _applicantService.UpdateApplicantAsync(applicant);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _applicantService.DeleteApplicantAsync(id);
            if (!result)
                return NotFound("Silinecek başvuru sahibi bulunamadı.");
            return NoContent();
        }
    }
}
