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
    [Route("/api/organization/divisions")]
    public class DivisionController : BaseController
    {
        public DivisionController(IMapper mapper, ITripsUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListDivision()
        {
            var divisions = await _unitOfWork.Organization.ListDivision();

            return Ok(_mapper.Map<ICollection<Division>, ICollection<DivisionResource>>(divisions));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetDivision(int id)
        {
            var division = await _unitOfWork.Organization.GetDivision(id);

            return Ok(_mapper.Map<Division, DivisionResource>(division));
        }

        [HttpGet, Route("{id}/branches")]
        public async Task<IActionResult> ListBranchForDivision(int id)
        {
            var branches = await _unitOfWork.Organization.FindBranches(b => b.DivisionId == id);

            return Ok(_mapper.Map<ICollection<Branch>, ICollection<BranchResource>>(branches));
        }

        [HttpGet, Route("{id}/branches/updatable")]
        public async Task<IActionResult> ListBranchForDivisionUpdatable(int id)
        {
            //TBD: to implement logic
            return await ListBranchForDivision(id);
        }

        [HttpGet, Route("{id}/cans")]
        public async Task<IActionResult> ListCanForDivision(int id)
        {
            var cans = await _unitOfWork.Organization.FindCans(c => c.DivisionId == id);

            return Ok(_mapper.Map<ICollection<Can>, ICollection<CanResource>>(cans));
        }

        [HttpGet, Route("{id}/cans/updatable")]
        public async Task<IActionResult> ListCanForDivisionUpdatable(int id)
        {
            //TBD: to implement logic
            return await ListCanForDivision(id);
        }

        [HttpGet, Route("{id}/canallocations")]
        public async Task<IActionResult> ListCanAllocationForDivision(int id)
        {
            var canAllocations = await _unitOfWork.Allocations.FindCanAllocations(c => c.DivisionId == id);

            return Ok(_mapper.Map<ICollection<CanAllocation>, ICollection<CanAllocationResource>>(canAllocations));
        }

        [HttpGet, Route("{id}/cansallocations/updatable")]
        public async Task<IActionResult> ListCanAllocationForDivisionUpdatable(int id)
        {
            //TBD: to implement logic
            return await ListCanAllocationForDivision(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddDivision([FromBody] DivisionResource divisionResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var division = _mapper.Map<DivisionResource, Division>(divisionResource);
            division.Status = Status.Active;
            division.StatusUpdateUserNEDId = "system";
            division.StatusUpdateDateTime = DateTime.UtcNow;
            division.CreateUserNEDId = "system";
            division.CreateDateTime = DateTime.UtcNow;

            _unitOfWork.Organization.AddDivision(division);
            await _unitOfWork.Complete();

            return await GetDivision(division.DivisionId);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateDivision(int id, [FromBody] DivisionResource divisionResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var division = await _unitOfWork.Organization.GetDivision(id);
            if (division == null) 
            {
                return NotFound();
            }  
            _mapper.Map<DivisionResource, Division>(divisionResource, division);
            division.LastUpdateUserNEDId = "system";
            division.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return await GetDivision(division.DivisionId);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteDivision(int id)
        {
            var division = await _unitOfWork.Organization.GetDivision(id);  
            if (division == null) 
            {
                return NotFound();
            }  
            division.Status = Status.Inactive;
            division.StatusUpdateUserNEDId = "system";
            division.StatusUpdateDateTime = DateTime.UtcNow;
            division.LastUpdateUserNEDId = "system";
            division.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return Ok("{ \"divisionId\": " + id.ToString() + ", \"deleted\": true}");
        }
    }
}