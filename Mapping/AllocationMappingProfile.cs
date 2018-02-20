using AutoMapper;
using Trips.Controllers.Resources;
using Trips.Models;

namespace Trips.Mapping
{
    public class AllocationMappingProfile : Profile
    {
        public AllocationMappingProfile()
        {
            CreateMap<CanAllocation, CanAllocationResource>();
            CreateMap<CanAllocation, CanAllocationSummaryResource>();
            CreateMap<CanAllocationResource, CanAllocation>()
                .ForMember(ca => ca.CanAllocationId, opt => opt.Ignore())
                .ForMember(ca => ca.Division, opt => opt.Ignore())
                .ForMember(ca => ca.Branch, opt => opt.Ignore())
                .ForMember(ca => ca.Can, opt => opt.Ignore());

            CreateMap<CanSubAllocation, CanSubAllocationResource>();
            CreateMap<CanSubAllocationResource, CanSubAllocation>()
                .ForMember(csa => csa.CanSubAllocationId, opt => opt.Ignore())
                .ForMember(csa => csa.CanAllocation, opt => opt.Ignore());
        }
    }
}