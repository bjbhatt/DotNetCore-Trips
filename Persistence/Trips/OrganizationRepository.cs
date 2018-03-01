using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trips.Models;

namespace Trips.Persistence
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly TripsDbContext _context;
        public OrganizationRepository(TripsDbContext context)
        {
            _context = context;
        }

        private IQueryable<Institute> _institutes 
        {
            get 
            {
                return _context.Institutes
                    .Include(i => i.Divisions)
                    .Where (i => i.Status == Status.Active);
            }
        }
        public async Task<ICollection<Institute>> ListInstitute() 
        {
            return await _institutes.ToListAsync();    
        } 
        public async Task<Institute> GetInstitute(int instituteId) 
        {
            return await _institutes.SingleOrDefaultAsync( i => i.InstituteId == instituteId);    
        } 
        public async void AddInstitute(Institute institute) 
        {
            await _context.Institutes.AddAsync(institute);
        }
        public async Task<ICollection<Institute>> FindInstitutes(Expression<Func<Institute, bool>> predicate) 
        {
            return await _institutes.Where(predicate).ToListAsync();    
        }
        public async Task<Institute> FindSingleInstitute(Expression<Func<Institute, bool>> predicate) 
        {
            return await _institutes.SingleOrDefaultAsync(predicate);    
        }

        private IQueryable<Division> _divisions 
        {
            get 
            {
                return _context.Divisions
                    .Include(d => d.Institute)
                    .Include(d => d.Branches)
                    .Include(d => d.Cans)
                    .Where(d => d.Status == Status.Active);
            }
        }
        public async Task<ICollection<Division>> ListDivision() 
        {
            return await _divisions.ToListAsync();    
        } 
        public async Task<Division> GetDivision(int divisionId) 
        {
            return await _divisions.SingleOrDefaultAsync(d => d.DivisionId == divisionId);    
        } 
        public async void AddDivision(Division division) 
        {
            await _context.Divisions.AddAsync(division);
        }
        public async Task<ICollection<Division>> FindDivisions(Expression<Func<Division, bool>> predicate) 
        {
            return await _divisions.Where(predicate).ToListAsync();    
        }
        public async Task<Division> FindSingleDivision(Expression<Func<Division, bool>> predicate) 
        {
            return await _divisions.SingleOrDefaultAsync(predicate);    
        }

        private IQueryable<Branch> _branches 
        {
            get 
            {
                return _context.Branches
                    .Include (c => c.CanAllocations)
                    .Include(b => b.Division)
                        .ThenInclude(d => d.Institute)
                    .Where(b => b.Status == Status.Active);
            }
        }
        public async Task<ICollection<Branch>> ListBranch() 
        {
            return await _branches.ToListAsync();    
        } 
        public async Task<Branch> GetBranch(int branchId) 
        {
            return await _branches.SingleOrDefaultAsync(b => b.BranchId == branchId);    
        } 
        public async void AddBranch(Branch branch) 
        {
            await _context.Branches.AddAsync(branch);
        }
        public async Task<ICollection<Branch>> FindBranches(Expression<Func<Branch, bool>> predicate) 
        {
            return await _branches.Where(predicate).ToListAsync();    
        }
        public async Task<Branch> FindSingleBranch(Expression<Func<Branch, bool>> predicate) 
        {
            return await _branches.SingleOrDefaultAsync(predicate);    
        }

        private IQueryable<Can> _cans 
        {
            get 
            {
                return _context.Cans
                    .Include (c => c.CanAllocations)
                    .Include(b => b.Division)
                        .ThenInclude(d => d.Institute)
                    .Where(c => c.Status == Status.Active);
            }
        }
        public async Task<ICollection<Can>> ListCan() 
        {
            return await _cans.ToListAsync();    
        } 
        public async Task<Can> GetCan(int canId) 
        {
            return await _cans.SingleOrDefaultAsync(c => c.CanId == canId);    
        } 
        public async void AddCan(Can can) 
        {
            await _context.Cans.AddAsync(can);
        }
        public async Task<ICollection<Can>> FindCans(Expression<Func<Can, bool>> predicate) 
        {
            return await _cans.Where(predicate).ToListAsync();    
        }
        public async Task<Can> FindSingleCan(Expression<Func<Can, bool>> predicate) 
        {
            return await _cans.SingleOrDefaultAsync(predicate);    
        }

        private IQueryable<InvitationalTraveler> _invitationalTraveler 
        {
            get 
            {
                return _context.InvitationalTravelers
                    .Include(b => b.Division)
                        .ThenInclude(d => d.Institute)
                    .Where(it => it.Status == Status.Active);
            }
        }public async Task<ICollection<InvitationalTraveler>> ListInvitationalTraveler() 
        {
            return await _invitationalTraveler.ToListAsync();    
        } 
        public async Task<InvitationalTraveler> GetInvitationalTraveler(int invitationalTravelerId) 
        {
            return await _invitationalTraveler.SingleOrDefaultAsync(it => it.InvitationalTravelerId == invitationalTravelerId);    
        } 
        public async void AddInvitationalTraveler(InvitationalTraveler invitationalTraveler) 
        {
            await _context.InvitationalTravelers.AddAsync(invitationalTraveler);
        }
        public async Task<ICollection<InvitationalTraveler>> FindInvitationalTravelers(Expression<Func<InvitationalTraveler, bool>> predicate) 
        {
            return await _invitationalTraveler.Where(predicate).ToListAsync();    
        }
        public async Task<InvitationalTraveler> FindSingleInvitationalTraveler(Expression<Func<InvitationalTraveler, bool>> predicate) 
        {
            return await _invitationalTraveler.SingleOrDefaultAsync(predicate);    
        }
    }
}