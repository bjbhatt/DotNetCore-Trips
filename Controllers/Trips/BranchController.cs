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
    [Route("/api/organization/branches")]
    public class BranchController : BaseController
    {
        public BranchController(IMapper mapper, ITripsUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListBranch()
        {
            var branches = await _unitOfWork.Organization.ListBranch();

            return Ok(_mapper.Map<ICollection<Branch>, ICollection<BranchResource>>(branches));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetBranch(int id)
        {
            var branch = await _unitOfWork.Organization.GetBranch(id);

            return Ok(_mapper.Map<Branch, BranchResource>(branch));
        }

        [HttpGet, Route("{id}/canallocations")]
        public async Task<IActionResult> ListCanAllocationForBranch(int id)
        {
            var canallocations = await _unitOfWork.Allocations.FindCanAllocations(ca => ca.BranchId == id);

            return Ok(_mapper.Map<ICollection<CanAllocation>, ICollection<CanAllocationResource>>(canallocations));
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] BranchResource branchResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var branch = _mapper.Map<BranchResource, Branch>(branchResource);
            branch.Status = Status.Active;
            branch.StatusUpdateUserNEDId = "system";
            branch.StatusUpdateDateTime = DateTime.UtcNow;
            branch.CreateUserNEDId = "system";
            branch.CreateDateTime = DateTime.UtcNow;

            _unitOfWork.Organization.AddBranch(branch);
            await _unitOfWork.Complete();

            return await GetBranch(branch.BranchId);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] BranchResource branchResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var branch = await _unitOfWork.Organization.GetBranch(id);
            if (branch == null) 
            {
                return NotFound();
            }  
            _mapper.Map<BranchResource, Branch>(branchResource, branch);
            branch.LastUpdateUserNEDId = "system";
            branch.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return await GetBranch(branch.BranchId);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await _unitOfWork.Organization.GetBranch(id);  
            if (branch == null) 
            {
                return NotFound();
            }  
            branch.Status = Status.Inactive;
            branch.StatusUpdateUserNEDId = "system";
            branch.StatusUpdateDateTime = DateTime.UtcNow;
            branch.LastUpdateUserNEDId = "system";
            branch.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return Ok("{ \"branchId\": " + id.ToString() + ", \"deleted\": true}");
        }
    }
}