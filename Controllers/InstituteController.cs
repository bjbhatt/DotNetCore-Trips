using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trips.Controllers.Resources;
using Trips.Models;
using Trips.Persistence;

namespace Trips.Controllers
{
    [Route("/api/organization/institutes")]
    public class InstituteController : BaseController
    {
        public InstituteController(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListInstitute()
        {
            var institutes = await _unitOfWork.Organization.ListInstitute();

            return Ok(_mapper.Map<ICollection<Institute>, ICollection<InstituteResource>>(institutes));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetInstitute(int id)
        {
            var institute = await _unitOfWork.Organization.GetInstitute(id);

            return Ok(_mapper.Map<Institute, InstituteResource>(institute));
        }

        [HttpGet, Route("{id}/divisions")]
        public async Task<IActionResult> ListDivisionForInstitute(int id)
        {
            var divisions = await _unitOfWork.Organization.FindDivisions(d => d.InstituteId == id);

            return Ok(_mapper.Map<ICollection<Division>, ICollection<DivisionResource>>(divisions));
        }

        [HttpGet, Route("{id}/divisions/updatable")]
        public async Task<IActionResult> ListDivisionForInstituteUpdatable(int id)
        {
            //TBD: to implement logic
            return await ListDivisionForInstitute(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddInstitute([FromBody] InstituteResource instituteResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var institute = _mapper.Map<InstituteResource, Institute>(instituteResource);
            institute.Status = Status.Active;
            institute.StatusUpdateUserNEDId = "system";
            institute.StatusUpdateDateTime = DateTime.UtcNow;
            institute.CreateUserNEDId = "system";
            institute.CreateDateTime = DateTime.UtcNow;

            _unitOfWork.Organization.AddInstitute(institute);
            await _unitOfWork.Complete();

            return await GetInstitute(institute.InstituteId);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateInstitute(int id, [FromBody] InstituteResource instituteResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var institute = await _unitOfWork.Organization.GetInstitute(id);
            if (institute == null) 
            {
                return NotFound();
            }  
            _mapper.Map<InstituteResource, Institute>(instituteResource, institute);
            institute.LastUpdateUserNEDId = "system";
            institute.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return await GetInstitute(institute.InstituteId);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteInstitute(int id)
        {
            var institute = await _unitOfWork.Organization.GetInstitute(id);  
            if (institute == null) 
            {
                return NotFound();
            }  
            institute.Status = Status.Inactive;
            institute.StatusUpdateUserNEDId = "system";
            institute.StatusUpdateDateTime = DateTime.UtcNow;
            institute.LastUpdateUserNEDId = "system";
            institute.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return Ok("{ \"instituteId\": " + id.ToString() + ", \"deleted\": true}");
        }
    }
}