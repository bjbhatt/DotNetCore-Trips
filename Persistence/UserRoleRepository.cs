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
        public async Task<ICollection<Role>> ListRole() 
        {
            return await _context.Roles
                .Where(r => r.Status == Status.Active).ToListAsync();    
        } 
        public async Task<Role> GetRole(RoleEnum roleId) 
        {
            return await _context.Roles
                .SingleOrDefaultAsync(r => r.RoleId == roleId && r.Status == Status.Active);    
        } 
        public async void AddRole(Role role) 
        {
            await _context.Roles.AddAsync(role);
        }
        public async Task<ICollection<Role>> FindRoles(Expression<Func<Role, bool>> predicate) 
        {
            return await _context.Roles
                .Where(r => r.Status == Status.Active)
                .Where(predicate).ToListAsync();    
        } 
        public async Task<Role> FindSingleRole(Expression<Func<Role, bool>> predicate) 
        {
            return await _context.Roles
                .Where(r => r.Status == Status.Active)
                .SingleOrDefaultAsync(predicate);    
        } 
        
        public async Task<ICollection<User>> ListUser() 
        {
            return await _context.Users
                .Where(u => u.Status == Status.Active).ToListAsync();    
        } 
        public async Task<User> GetUser(string nedId) 
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.NEDId == nedId && u.Status == Status.Active);    
        } 
        public async void AddUser(User user) 
        {
            await _context.Users.AddAsync(user);
        }
        public async Task<ICollection<User>> FindUsers(Expression<Func<User, bool>> predicate) 
        {
            return await _context.Users
                .Where(u => u.Status == Status.Active)
                .Where(predicate).ToListAsync();    
        } 
        public async Task<User> FindSingleUser(Expression<Func<User, bool>> predicate) 
        {
            return await _context.Users
                .Where(u => u.Status == Status.Active)
                .SingleOrDefaultAsync(predicate);    
        } 
        
        public async Task<ICollection<UserRole>> ListUserRole()
        {
            return await _context.UserRoles
                .Include(ur => ur.Role)
                .Include(ur => ur.User)
                .Where(ur => ur.Status == Status.Active).ToListAsync();    
        }
        public async Task<UserRole> GetUserRole(int userRoleId)
        {
            return await _context.UserRoles
                .Include(ur => ur.Role)
                .Include(ur => ur.User)
                .SingleOrDefaultAsync(ur => ur.UserRoleId == userRoleId && ur.Status == Status.Active);    
        }
        public async void AddUserRole(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
        }
        public async Task<ICollection<UserRole>> FindUserRoles(Expression<Func<UserRole, bool>> predicate)
        {
            return await _context.UserRoles
                .Include(ur => ur.Role)
                .Include(ur => ur.User)
                .Where(ur => ur.Status == Status.Active)
                .Where(predicate)
                .ToListAsync();    
        }
        public async Task<UserRole> FindSingleUserRole(Expression<Func<UserRole, bool>> predicate)
        {
            return await _context.UserRoles
                .Include(ur => ur.Role)
                .Include(ur => ur.User)
                .Where(predicate)
                .SingleOrDefaultAsync(ur => ur.Status == Status.Active);    
        }
    }
}