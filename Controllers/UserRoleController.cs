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
    [Route("/api/userroles")]
    public class UserRoleController : BaseController
    {
        public UserRoleController(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListUserRole()
        {
            var userRoles = await _unitOfWork.UserRoles.ListUserRole();

            return Ok(_mapper.Map<ICollection<UserRole>, ICollection<UserRoleResource>>(userRoles));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetUserRole(int id)
        {
            var userRole = await _unitOfWork.UserRoles.GetUserRole(id);

            return Ok(_mapper.Map<UserRole, UserRoleResource>(userRole));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleResource userRoleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userRole = _mapper.Map<UserRoleResource, UserRole>(userRoleResource);
            userRole.Status = Status.Active;
            userRole.StatusUpdateUserNEDId = "system";
            userRole.StatusUpdateDateTime = DateTime.UtcNow;
            userRole.CreateUserNEDId = "system";
            userRole.CreateDateTime = DateTime.UtcNow;

            _unitOfWork.UserRoles.AddUserRole(userRole);
            await _unitOfWork.Complete();

            return await GetUserRole(userRole.UserRoleId);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] UserRoleResource userRoleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userRole = await _unitOfWork.UserRoles.GetUserRole(id);
            if (userRole == null)
            {
                return NotFound();
            }
            _mapper.Map<UserRoleResource, UserRole>(userRoleResource, userRole);
            userRole.LastUpdateUserNEDId = "system";
            userRole.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return await GetUserRole(userRole.UserRoleId);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var userRole = await _unitOfWork.UserRoles.GetUserRole(id);
            if (userRole == null)
            {
                return NotFound();
            }
            userRole.Status = Status.Inactive;
            userRole.StatusUpdateUserNEDId = "system";
            userRole.StatusUpdateDateTime = DateTime.UtcNow;
            userRole.LastUpdateUserNEDId = "system";
            userRole.LastUpdateDateTime = DateTime.UtcNow;

            await _unitOfWork.Complete();

            return Ok("{ \"userRoleId\": " + id.ToString() + ", \"deleted\": true}");
        }
    }
}