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
    [Route("/api/users")]
    public class UserController : BaseController
    {
        public UserController(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListUser()
        {
            var users = await _unitOfWork.UserRoles.ListUser();

            return Ok(_mapper.Map<ICollection<User>, ICollection<UserResource>>(users));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _unitOfWork.UserRoles.GetUser(id);

            return Ok(_mapper.Map<User, UserResource>(user));
        }

        [HttpGet, Route("search/{searchText}")]
        public async Task<IActionResult> SearchUser(string searchText)
        {
            var users = await _unitOfWork.UserRoles
                .FindUsers(u => u.FirstName.StartsWith(searchText) ||
                                u.LastName.StartsWith(searchText) ||
                                u.FullName.StartsWith(searchText) ||
                                u.FullNameLegal.StartsWith(searchText) ||
                                u.NEDId.StartsWith(searchText));

            return Ok(_mapper.Map<ICollection<User>, ICollection<UserResource>>(users));
        }
    }
}