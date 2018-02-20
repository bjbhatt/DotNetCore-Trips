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
    [Route("/api/organization/cans")]
    public class CanController :BaseController
    {
        public CanController(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListCan()
        {
            var cans = await _unitOfWork.Organization.ListCan();

            return Ok(_mapper.Map<ICollection<Can>, ICollection<CanResource>>(cans));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCan(int id)
        {
            var can = await _unitOfWork.Organization.GetCan(id);

            return Ok(_mapper.Map<Can, CanResource>(can));
        }

        [HttpGet, Route("{id}/canallocations")]
        public async Task<IActionResult> ListCanAllocationForCan(int id)
        {
            var canallocations = await _unitOfWork.Allocations.FindCanAllocations(ca => ca.CanId == id);

            return Ok(_mapper.Map<ICollection<CanAllocation>, ICollection<CanAllocationResource>>(canallocations));
        }

        [HttpPost]
        public async Task<IActionResult> AddCan([FromBody] CanResource canResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var can = _mapper.Map<CanResource, Can>(canResource);
            can.Status = Status.Active;
            can.StatusUpdateUserNEDId = "system";
            can.StatusUpdateDateTime = DateTime.UtcNow;
            can.CreateUserNEDId = "system";
            can.CreateDateTime = DateTime.UtcNow;

            _unitOfWork.Organization.AddCan(can);
            await _unitOfWork.Complete();

            return await GetCan(can.CanId);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateCan(int id, [FromBody] CanResource canResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var can = await _unitOfWork.Organization.GetCan(id);
            if (can == null)
            {
                return NotFound();
            }
            _mapper.Map<CanResource, Can>(canResource, can);
            can.LastUpdateUserNEDId = "system";
            can.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return await GetCan(can.CanId);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteCan(int id)
        {
            var can = await _unitOfWork.Organization.GetCan(id);
            if (can == null)
            {
                return NotFound();
            }
            can.Status = Status.Inactive;
            can.StatusUpdateUserNEDId = "system";
            can.StatusUpdateDateTime = DateTime.UtcNow;
            can.LastUpdateUserNEDId = "system";
            can.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return Ok("{ \"canId\": " + id.ToString() + ", \"deleted\": true}");
        }
    }
}