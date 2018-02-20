using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trips.Models;

namespace Trips.Persistence
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly TripsDbContext _context;
        public UserRoleRepository(TripsDbContext context)
        {
            _context = context;
        }
        
        private IQueryable<Role> _roles 
        {
            get 
            {
                return _context.Roles
                    .Where(r => r.Status == Status.Active);
            }
        }
        public async Task<ICollection<Role>> ListRole() 
        {
            return await _roles.ToListAsync();    
        } 
        public async Task<Role> GetRole(RoleEnum roleId) 
        {
            return await _roles.SingleOrDefaultAsync(r => r.RoleId == roleId);    
        } 
        public async void AddRole(Role role) 
        {
            await _context.Roles.AddAsync(role);
        }
        public async Task<ICollection<Role>> FindRoles(Expression<Func<Role, bool>> predicate) 
        {
            return await _roles.Where(predicate).ToListAsync();    
        } 
        public async Task<Role> FindSingleRole(Expression<Func<Role, bool>> predicate) 
        {
            return await _roles.SingleOrDefaultAsync(predicate);    
        } 
        
        private IQueryable<User> _users 
        {
            get 
            {
                return _context.Users
                    .Where(r => r.Status == Status.Active);
            }
        }
        public async Task<ICollection<User>> ListUser() 
        {
            return await _users.ToListAsync();    
        } 
        public async Task<User> GetUser(string nedId) 
        {
            return await _users.SingleOrDefaultAsync(u => u.NEDId == nedId);    
        } 
        public async void AddUser(User user) 
        {
            await _context.Users.AddAsync(user);
        }
        public async Task<ICollection<User>> FindUsers(Expression<Func<User, bool>> predicate) 
        {
            return await _users.Where(predicate).ToListAsync();    
        } 
        public async Task<User> FindSingleUser(Expression<Func<User, bool>> predicate) 
        {
            return await _users.SingleOrDefaultAsync(predicate);    
        } 
        
        private IQueryable<UserRole> _userRoles
        {
            get 
            {
                return _context.UserRoles
                    .Include(ur => ur.Role)
                    .Include(ur => ur.User)
                    .Where(r => r.Status == Status.Active);
            }
        }
        public async Task<ICollection<UserRole>> ListUserRole()
        {
            return await _userRoles.ToListAsync();    
        }
        public async Task<UserRole> GetUserRole(int userRoleId)
        {
            return await _userRoles.SingleOrDefaultAsync(ur => ur.UserRoleId == userRoleId);    
        }
        public async void AddUserRole(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
        }
        public async Task<ICollection<UserRole>> FindUserRoles(Expression<Func<UserRole, bool>> predicate)
        {
            return await _userRoles.Where(predicate).ToListAsync();    
        }
        public async Task<UserRole> FindSingleUserRole(Expression<Func<UserRole, bool>> predicate)
        {
            return await _userRoles.SingleOrDefaultAsync(predicate);    
        }
    }
}