using AutoMapper;
using Trips.Controllers.Resources;
using Trips.Models;

namespace Trips.Mapping
{
    public class UserRoleMappingProfile : Profile
    {
        public UserRoleMappingProfile()
        {
            CreateMap<Role, RoleResource>(); 
            CreateMap<RoleResource, Role>(); 

            CreateMap<User, UserResource>();
            CreateMap<UserResource, User>();

            CreateMap<UserRole, UserRoleResource>();
            CreateMap<UserRoleResource, UserRole>()
                .ForMember(ur => ur.UserRoleId, opt => opt.Ignore())
                .ForMember(ur => ur.User, opt => opt.Ignore())
                .ForMember(ur => ur.Role, opt => opt.Ignore())
                .ForMember(ur => ur.Institute, opt => opt.Ignore())
                .ForMember(ur => ur.Division, opt => opt.Ignore())
                .ForMember(ur => ur.Branch, opt => opt.Ignore());
        }
    }
}