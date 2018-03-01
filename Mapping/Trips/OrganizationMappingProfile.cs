using AutoMapper;
using Trips.Controllers.Resources;
using Trips.Models;

namespace Trips.Mapping
{
    public class OrganizationMappingProfile : Profile
    {
        public OrganizationMappingProfile()
        {
            CreateMap<Institute, InstituteResource>();
            CreateMap<Institute, InstituteSummaryResource>();
            CreateMap<InstituteResource, Institute>()
                .ForMember(i => i.InstituteId, opt => opt.Ignore());

            CreateMap<Division, DivisionResource>();
            CreateMap<Division, DivisionSummaryResource>();
            CreateMap<DivisionResource, Division>()
                .ForMember(d => d.DivisionId, opt => opt.Ignore())
                .ForMember(d => d.Institute, opt => opt.Ignore());


            CreateMap<Branch, BranchResource>();
            CreateMap<Branch, BranchSummaryResource>();
            CreateMap<BranchResource, Branch>()
                .ForMember(b => b.BranchId, opt => opt.Ignore())
                .ForMember(b => b.Division, opt => opt.Ignore());

            CreateMap<Can, CanResource>();
            CreateMap<Can, CanSummaryResource>();
            CreateMap<CanResource, Can>()
                .ForMember(c => c.CanId, opt => opt.Ignore())
                .ForMember(c => c.Division, opt => opt.Ignore());

            CreateMap<InvitationalTraveler, InvitationalTravelerResource>();
            CreateMap<InvitationalTravelerResource, InvitationalTraveler>()
                .ForMember(it => it.InvitationalTravelerId, opt => opt.Ignore())
                .ForMember(it => it.Division, opt => opt.Ignore());

        }
    }
}