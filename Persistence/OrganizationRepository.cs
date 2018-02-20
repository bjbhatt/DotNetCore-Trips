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

        public async Task<ICollection<Institute>> ListInstitute() 
        {
            return await _context.Institutes
                .Include(i => i.Divisions)
                .ToListAsync();    
        } 
        public async Task<Institute> GetInstitute(int instituteId) 
        {
            return await _context.Institutes
                .Include(i => i.Divisions)
                .SingleOrDefaultAsync( i => i.InstituteId == instituteId);    
        } 
        public async void AddInstitute(Institute institute) 
        {
            await _context.Institutes.AddAsync(institute);
        }
        public async Task<ICollection<Institute>> FindInstitutes(Expression<Func<Institute, bool>> predicate) 
        {
            return await _context.Institutes
                .Include(i => i.Divisions)
                .Where(predicate).ToListAsync();    
        }
        public async Task<Institute> FindSingleInstitute(Expression<Func<Institute, bool>> predicate) 
        {
            return await _context.Institutes
                .Include(i => i.Divisions)
                .SingleOrDefaultAsync(predicate);    
        }

        public async Task<ICollection<Division>> ListDivision() 
        {
            return await _context.Divisions
                .Include(d => d.Institute)
                .Include(d => d.Branches)
                .Include(d => d.Cans)
                .Where(d => d.Status == Status.Active).ToListAsync();    
        } 
        public async Task<Division> GetDivision(int divisionId) 
        {
            return await _context.Divisions
                .Include(d => d.Institute)
                .Include(d => d.Branches)
                .Include(d => d.Cans)
                .SingleOrDefaultAsync(d => d.DivisionId == divisionId && d.Status == Status.Active);    
        } 
        public async void AddDivision(Division division) 
        {
            await _context.Divisions.AddAsync(division);
        }
        public async Task<ICollection<Division>> FindDivisions(Expression<Func<Division, bool>> predicate) 
        {
            return await _context.Divisions
                .Include(d => d.Institute)
                .Include(d => d.Branches)
                .Include(d => d.Cans)
                .Where(d => d.Status == Status.Active)
                .Where(predicate).ToListAsync();    
        }
        public async Task<Division> FindSingleDivision(Expression<Func<Division, bool>> predicate) 
        {
            return await _context.Divisions
                .Include(d => d.Institute)
                .Include(d => d.Branches)
                .Include(d => d.Cans)
                .Where(d => d.Status == Status.Active)
                .SingleOrDefaultAsync(predicate);    
        }

        public async Task<ICollection<Branch>> ListBranch() 
        {
            return await _context.Branches
                .Include (c => c.CanAllocations)
                .Include(b => b.Division)
                    .ThenInclude(d => d.Institute)
                .Where(b => b.Status == Status.Active).ToListAsync();    
        } 
        public async Task<Branch> GetBranch(int branchId) 
        {
            return await _context.Branches
                .Include (c => c.CanAllocations)
                .Include(b => b.Division)
                    .ThenInclude(d => d.Institute)
                .SingleOrDefaultAsync(b => b.BranchId == branchId && b.Status == Status.Active);    
        } 
        public async void AddBranch(Branch branch) 
        {
            await _context.Branches.AddAsync(branch);
        }
        public async Task<ICollection<Branch>> FindBranches(Expression<Func<Branch, bool>> predicate) 
        {
            return await _context.Branches
                .Include (b => b.CanAllocations)
                .Include(b => b.Division)
                    .ThenInclude(d => d.Institute)
                .Where(b => b.Status == Status.Active)
                .Where(predicate).ToListAsync();    
        }
        public async Task<Branch> FindSingleBranch(Expression<Func<Branch, bool>> predicate) 
        {
            return await _context.Branches
                .Include (b => b.CanAllocations)
                .Include(b => b.Division)
                    .ThenInclude(d => d.Institute)
                .Where(b => b.Status == Status.Active)
                .SingleOrDefaultAsync(predicate);    
        }

        public async Task<ICollection<Can>> ListCan() 
        {
            return await _context.Cans
                .Include (c => c.CanAllocations)
                .Include(c => c.Division)
                    .ThenInclude(d => d.Institute)
                .Where(c => c.Status == Status.Active).ToListAsync();    
        } 
        public async Task<Can> GetCan(int canId) 
        {
            return await _context.Cans
                .Include (c => c.CanAllocations)
                .Include(c => c.Division)
                    .ThenInclude(d => d.Institute)
                .SingleOrDefaultAsync(c => c.CanId == canId && c.Status == Status.Active);    
        } 
        public async void AddCan(Can can) 
        {
            await _context.Cans.AddAsync(can);
        }
        public async Task<ICollection<Can>> FindCans(Expression<Func<Can, bool>> predicate) 
        {
            return await _context.Cans
                .Include (c => c.CanAllocations)
                .Include(c => c.Division)
                    .ThenInclude(d => d.Institute)
                .Where(c => c.Status == Status.Active)
                .Where(predicate).ToListAsync();    
        }
        public async Task<Can> FindSingleCan(Expression<Func<Can, bool>> predicate) 
        {
            return await _context.Cans
                .Include (c => c.CanAllocations)
                .Include(c => c.Division)
                    .ThenInclude(d => d.Institute)
                .Where(c => c.Status == Status.Active)
                .SingleOrDefaultAsync(predicate);    
        }

        public async Task<ICollection<InvitationalTraveler>> ListInvitationalTraveler() 
        {
            return await _context.InvitationalTravelers
                .Include(it => it.Division)
                    .ThenInclude(d => d.Institute)
                .Where(it => it.Status == Status.Active).ToListAsync();    
        } 
        public async Task<InvitationalTraveler> GetInvitationalTraveler(int invitationalTravelerId) 
        {
            return await _context.InvitationalTravelers
                .Include(it => it.Division)
                    .ThenInclude(d => d.Institute)
                .SingleOrDefaultAsync(it => it.InvitationalTravelerId == invitationalTravelerId && it.Status == Status.Active);    
        } 
        public async void AddInvitationalTraveler(InvitationalTraveler invitationalTraveler) 
        {
            await _context.InvitationalTravelers.AddAsync(invitationalTraveler);
        }
        public async Task<ICollection<InvitationalTraveler>> FindInvitationalTravelers(Expression<Func<InvitationalTraveler, bool>> predicate) 
        {
            return await _context.InvitationalTravelers
                .Include(it => it.Division)
                    .ThenInclude(d => d.Institute)
                .Where(it => it.Status == Status.Active)
                .Where(predicate).ToListAsync();    
        }
        public async Task<InvitationalTraveler> FindSingleInvitationalTraveler(Expression<Func<InvitationalTraveler, bool>> predicate) 
        {
            return await _context.InvitationalTravelers
                .Include(it => it.Division)
                    .ThenInclude(d => d.Institute)
                .Where(it => it.Status == Status.Active)
                .SingleOrDefaultAsync(predicate);    
        }
    }
}