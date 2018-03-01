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
    [Route("/api/organization/invitationaltravelers")]
    public class InvitationalTravelerController : BaseController
    {
        public InvitationalTravelerController(IMapper mapper, ITripsUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListInvitationalTraveler()
        {
            var invitationalTravelers = await _unitOfWork.Organization.ListInvitationalTraveler();

            return Ok(_mapper.Map<ICollection<InvitationalTraveler>, ICollection<InvitationalTravelerResource>>(invitationalTravelers));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetInvitationalTraveler(int id)
        {
            var invitationalTraveler = await _unitOfWork.Organization.GetInvitationalTraveler(id);

            return Ok(_mapper.Map<InvitationalTraveler, InvitationalTravelerResource>(invitationalTraveler));
        }

        [HttpPost]
        public async Task<IActionResult> AddInvitationalTraveler([FromBody] InvitationalTravelerResource invitationalTravelerResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invitationalTraveler = _mapper.Map<InvitationalTravelerResource, InvitationalTraveler>(invitationalTravelerResource);
            invitationalTraveler.Status = Status.Active;
            invitationalTraveler.StatusUpdateUserNEDId = "system";
            invitationalTraveler.StatusUpdateDateTime = DateTime.UtcNow;
            invitationalTraveler.CreateUserNEDId = "system";
            invitationalTraveler.CreateDateTime = DateTime.UtcNow;

            _unitOfWork.Organization.AddInvitationalTraveler(invitationalTraveler);
            await _unitOfWork.Complete();

            return await GetInvitationalTraveler(invitationalTraveler.InvitationalTravelerId);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateInvitationalTraveler(int id, [FromBody] InvitationalTravelerResource invitationalTravelerResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invitationalTraveler = await _unitOfWork.Organization.GetInvitationalTraveler(id);
            if (invitationalTraveler == null)
            {
                return NotFound();
            }
            _mapper.Map<InvitationalTravelerResource, InvitationalTraveler>(invitationalTravelerResource, invitationalTraveler);
            invitationalTraveler.LastUpdateUserNEDId = "system";
            invitationalTraveler.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return await GetInvitationalTraveler(invitationalTraveler.InvitationalTravelerId);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteInvitationalTraveler(int id)
        {
            var invitationalTraveler = await _unitOfWork.Organization.GetInvitationalTraveler(id);
            if (invitationalTraveler == null)
            {
                return NotFound();
            }
            invitationalTraveler.Status = Status.Inactive;
            invitationalTraveler.StatusUpdateUserNEDId = "system";
            invitationalTraveler.StatusUpdateDateTime = DateTime.UtcNow;
            invitationalTraveler.LastUpdateUserNEDId = "system";
            invitationalTraveler.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return Ok("{ \"invitationalTravelerId\": " + id.ToString() + ", \"deleted\": true}");
        }
    }
}