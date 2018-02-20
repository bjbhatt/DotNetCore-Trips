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
    [Route("/api/roles")]
    public class RoleController : BaseController
    {
        public RoleController(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListRole()
        {
            var roles = await _unitOfWork.UserRoles.ListRole();

            return Ok(_mapper.Map<ICollection<Role>, ICollection<RoleResource>>(roles));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetUser(RoleEnum id)
        {
            var role = await _unitOfWork.UserRoles.GetRole(id);

            return Ok(_mapper.Map<Role, RoleResource>(role));
        }
    }
}