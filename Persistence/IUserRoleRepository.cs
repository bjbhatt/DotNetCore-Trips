using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trips.Models;

namespace Trips.Persistence
{
    public interface IUserRoleRepository
    {
        Task<ICollection<Role>> ListRole();
        Task<Role> GetRole(RoleEnum roleId); 
        void AddRole(Role role);
        Task<ICollection<Role>> FindRoles(Expression<Func<Role, bool>> predicate);
        Task<Role> FindSingleRole(Expression<Func<Role, bool>> predicate);

        Task<ICollection<User>> ListUser();
        Task<User> GetUser(string nedId); 
        void AddUser(User user);
        Task<ICollection<User>> FindUsers(Expression<Func<User, bool>> predicate);
        Task<User> FindSingleUser(Expression<Func<User, bool>> predicate);

        Task<ICollection<UserRole>> ListUserRole();
        Task<UserRole> GetUserRole(int userRoleId); 
        void AddUserRole(UserRole userRole);
        Task<ICollection<UserRole>> FindUserRoles(Expression<Func<UserRole, bool>> predicate);
        Task<UserRole> FindSingleUserRole(Expression<Func<UserRole, bool>> predicate);

    }
}