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
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly ITripsUnitOfWork _unitOfWork;
        public BaseController(IMapper mapper, ITripsUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}