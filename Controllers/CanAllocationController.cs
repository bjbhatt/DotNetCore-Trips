using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trips.Controllers.Resources;
using Trips.Models;
using Trips.Persistence;

namespace Trips.Controllers
{
    [Route("/api/allocations/canallocations")]
    public class CanAllocationController : BaseController
    {
        public CanAllocationController(IMapper mapper, ITripsUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        private void resetCanSubAllocations(CanAllocation canAllocation)
        {
            //** If Update/Delete, remove existing sub-allocations */
            if (canAllocation.CanAllocationId != 0 && canAllocation.CanSubAllocations != null) 
            {
                foreach (var canSubAllocation in canAllocation.CanSubAllocations.Where(csa => csa.Status == Status.Active))
                {
                    canSubAllocation.Status = Status.Inactive;
                    canSubAllocation.StatusUpdateDateTime = DateTime.UtcNow;
                    canSubAllocation.StatusUpdateUserNEDId = "system";
                    canSubAllocation.LastUpdateDateTime = DateTime.UtcNow;
                    canSubAllocation.LastUpdateUserNEDId = "system";
                }
            }
            //** If Add/Update, add new sub-allocations */
            if (canAllocation.Status == Status.Active)
            {
                if (canAllocation.CanSubAllocations == null) 
                {
                    canAllocation.CanSubAllocations = new List<CanSubAllocation>();
                }
                //TBD: to implement insertion
            }
        }
        [HttpGet]
        public async Task<IActionResult> ListCanAllocation()
        {
            var canAllocations = await _unitOfWork.Allocations.ListCanAllocation();

            return Ok(_mapper.Map<ICollection<CanAllocation>, ICollection<CanAllocationResource>>(canAllocations));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCanAllocation(int id)
        {
            var canAllocation = await _unitOfWork.Allocations.GetCanAllocation(id);

            return Ok(_mapper.Map<CanAllocation, CanAllocationResource>(canAllocation));
        }

        [HttpGet, Route("{id}/cansuballocations")]
        public async Task<IActionResult> GetSubCanAllocationForCanAllocation(int id)
        {
            var canSubAllocations = await _unitOfWork.Allocations.FindCanSubAllocations(csa => csa.CanAllocationId == id);

            return Ok(_mapper.Map<ICollection<CanSubAllocation>, ICollection<CanSubAllocationResource>>(canSubAllocations));
        }

        [HttpPost]
        public async Task<IActionResult> AddCanAllocation([FromBody] CanAllocationResource canAllocationResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var canAllocation = _mapper.Map<CanAllocationResource, CanAllocation>(canAllocationResource);
            canAllocation.Status = Status.Active;
            canAllocation.StatusUpdateUserNEDId = "system";
            canAllocation.StatusUpdateDateTime = DateTime.UtcNow;
            canAllocation.CreateUserNEDId = "system";
            canAllocation.CreateDateTime = DateTime.UtcNow;

            _unitOfWork.Allocations.AddCanAllocation(canAllocation);
            resetCanSubAllocations(canAllocation);

            await _unitOfWork.Complete();

            return await GetCanAllocation(canAllocation.CanAllocationId);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateCanAllocation(int id, [FromBody] CanAllocationResource canAllocationResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var canAllocation = await _unitOfWork.Allocations.GetCanAllocation(id);
            if (canAllocation == null) 
            {
                return NotFound();
            }  
            _mapper.Map<CanAllocationResource, CanAllocation>(canAllocationResource, canAllocation);
            canAllocation.LastUpdateUserNEDId = "system";
            canAllocation.LastUpdateDateTime = DateTime.UtcNow;
            resetCanSubAllocations(canAllocation);

            await _unitOfWork.Complete();

            return await GetCanAllocation(canAllocation.CanAllocationId);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteCanAllocation(int id)
        {
            var canAllocation = await _unitOfWork.Allocations.GetCanAllocation(id);  
            if (canAllocation == null) 
            {
                return NotFound();
            }  
            canAllocation.Status = Status.Inactive;
            canAllocation.StatusUpdateUserNEDId = "system";
            canAllocation.StatusUpdateDateTime = DateTime.UtcNow;
            canAllocation.LastUpdateUserNEDId = "system";
            canAllocation.LastUpdateDateTime = DateTime.UtcNow;
            resetCanSubAllocations(canAllocation);

            await _unitOfWork.Complete();

            return Ok("{ \"canAllocationId\": " + id.ToString() + ", \"deleted\": true}");
        }
    }
}