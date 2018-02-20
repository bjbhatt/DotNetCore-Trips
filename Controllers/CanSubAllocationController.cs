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
    [Route("/api/allocations/cansuballocations")]
    public class CanSubAllocationController : BaseController
    {
        public CanSubAllocationController(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListCanSubAllocation()
        {
            var canSubAllocations = await _unitOfWork.Allocations.ListCanSubAllocation();

            return Ok(_mapper.Map<ICollection<CanSubAllocation>, ICollection<CanSubAllocationResource>>(canSubAllocations));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCanSubAllocation(int id)
        {
            var canSubAllocation = await _unitOfWork.Allocations.GetCanSubAllocation(id);

            return Ok(_mapper.Map<CanSubAllocation, CanSubAllocationResource>(canSubAllocation));
        }

        [HttpPost]
        public async Task<IActionResult> AddCanSubAllocation([FromBody] CanSubAllocationResource canSubAllocationResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var canSubAllocation = _mapper.Map<CanSubAllocationResource, CanSubAllocation>(canSubAllocationResource);
            canSubAllocation.Status = Status.Active;
            canSubAllocation.StatusUpdateUserNEDId = "system";
            canSubAllocation.StatusUpdateDateTime = DateTime.UtcNow;
            canSubAllocation.CreateUserNEDId = "system";
            canSubAllocation.CreateDateTime = DateTime.UtcNow;

            _unitOfWork.Allocations.AddCanSubAllocation(canSubAllocation);

            await _unitOfWork.Complete();

            return await GetCanSubAllocation(canSubAllocation.CanSubAllocationId);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateCanSubAllocation(int id, [FromBody] CanSubAllocationResource canSubAllocationResource)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var canSubAllocation = await _unitOfWork.Allocations.GetCanSubAllocation(id);
            if (canSubAllocation == null) 
            {
                return NotFound();
            }  
            _mapper.Map<CanSubAllocationResource, CanSubAllocation>(canSubAllocationResource, canSubAllocation);
            canSubAllocation.LastUpdateUserNEDId = "system";
            canSubAllocation.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return await GetCanSubAllocation(canSubAllocation.CanSubAllocationId);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteCanSubAllocation(int id)
        {
            var canSubAllocation = await _unitOfWork.Allocations.GetCanSubAllocation(id);  
            if (canSubAllocation == null) 
            {
                return NotFound();
            }  
            canSubAllocation.Status = Status.Inactive;
            canSubAllocation.StatusUpdateUserNEDId = "system";
            canSubAllocation.StatusUpdateDateTime = DateTime.UtcNow;
            canSubAllocation.LastUpdateUserNEDId = "system";
            canSubAllocation.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return Ok("{ \"canAllocationId\": " + id.ToString() + ", \"deleted\": true}");
        }
    }
}