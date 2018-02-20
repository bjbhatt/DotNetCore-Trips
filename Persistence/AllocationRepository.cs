using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trips.Models;

namespace Trips.Persistence
{
    public class AllocationRepository : IAllocationRepository
    {
        private readonly TripsDbContext _context;
        public AllocationRepository(TripsDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<CanAllocation>> ListCanAllocation() 
        {
            return await _context.CanAllocations
                .Include(ca => ca.CanSubAllocations)
                .Include(ca => ca.Division)
                    .ThenInclude(d => d.Institute)
                .Include(ca => ca.Can)
                    .ThenInclude(c => c.Division)
                        .ThenInclude(d => d.Institute)
                .Include(ca => ca.Branch)
                    .ThenInclude(b => b.Division)
                        .ThenInclude(d => d.Institute)
                .Where(ca => ca.Status == Status.Active).ToListAsync();    
        } 
        public async Task<CanAllocation> GetCanAllocation(int canAllocationId) 
        {
            return await _context.CanAllocations
                .Include(ca => ca.CanSubAllocations)
                .Include(ca => ca.Division)
                    .ThenInclude(d => d.Institute)
                .Include(ca => ca.Can)
                    .ThenInclude(c => c.Division)
                        .ThenInclude(d => d.Institute)
                .Include(ca => ca.Branch)
                    .ThenInclude(b => b.Division)
                        .ThenInclude(d => d.Institute)
                .SingleOrDefaultAsync(ca => ca.CanAllocationId == canAllocationId && ca.Status == Status.Active);    
        } 
        public async void AddCanAllocation(CanAllocation canAllocation) 
        {
            await _context.CanAllocations.AddAsync(canAllocation);
        }
        public async Task<ICollection<CanAllocation>> FindCanAllocations(Expression<Func<CanAllocation, bool>> predicate) 
        {
            return await _context.CanAllocations
                .Include(ca => ca.CanSubAllocations)
                .Include(ca => ca.Division)
                    .ThenInclude(d => d.Institute)
                .Include(ca => ca.Can)
                    .ThenInclude(c => c.Division)
                        .ThenInclude(d => d.Institute)
                .Include(ca => ca.Branch)
                    .ThenInclude(b => b.Division)
                        .ThenInclude(d => d.Institute)
                .Where(ca => ca.Status == Status.Active)
                .Where(predicate).ToListAsync();    
        } 
        public async Task<CanAllocation> FindSingleCanAllocation(Expression<Func<CanAllocation, bool>> predicate) 
        {
            return await _context.CanAllocations
                .Include(ca => ca.CanSubAllocations)
                .Include(ca => ca.Division)
                    .ThenInclude(d => d.Institute)
                .Include(ca => ca.Can)
                    .ThenInclude(c => c.Division)
                        .ThenInclude(d => d.Institute)
                .Include(ca => ca.Branch)
                    .ThenInclude(b => b.Division)
                        .ThenInclude(d => d.Institute)
                .Where(ca => ca.Status == Status.Active)
                .SingleOrDefaultAsync(predicate);    
        } 
        
        public async Task<ICollection<CanSubAllocation>> ListCanSubAllocation()
        {
            return await _context.CanSubAllocations
                .Include(csa => csa.CanAllocation)
                    .ThenInclude(ca => ca.Can)
                        .ThenInclude(c => c.Division)
                            .ThenInclude(d => d.Institute)
                .Include(csa => csa.CanAllocation)
                    .ThenInclude(ca => ca.Branch)
                        .ThenInclude(b => b.Division)
                            .ThenInclude(d => d.Institute)
                .Where(csa => csa.Status == Status.Active).ToListAsync();    
        }
        public async Task<CanSubAllocation> GetCanSubAllocation(int canSubAllocationId)
        {
            return await _context.CanSubAllocations
                .Include(csa => csa.CanAllocation)
                    .ThenInclude(ca => ca.Can)
                        .ThenInclude(c => c.Division)
                            .ThenInclude(d => d.Institute)
                .Include(csa => csa.CanAllocation)
                    .ThenInclude(ca => ca.Branch)
                        .ThenInclude(b => b.Division)
                            .ThenInclude(d => d.Institute)
                .SingleOrDefaultAsync(csa => csa.CanAllocationId == canSubAllocationId && csa.Status == Status.Active);    
        }
        public async void AddCanSubAllocation(CanSubAllocation canSubAllocation)
        {
            await _context.CanSubAllocations.AddAsync(canSubAllocation);
        }
        public async Task<ICollection<CanSubAllocation>> FindCanSubAllocations(Expression<Func<CanSubAllocation, bool>> predicate)
        {
            return await _context.CanSubAllocations
                .Include(csa => csa.CanAllocation)
                    .ThenInclude(ca => ca.Can)
                        .ThenInclude(c => c.Division)
                            .ThenInclude(d => d.Institute)
                .Include(csa => csa.CanAllocation)
                    .ThenInclude(ca => ca.Branch)
                        .ThenInclude(b => b.Division)
                            .ThenInclude(d => d.Institute)
                .Where(csa => csa.Status == Status.Active)
                .Where(predicate)
                .ToListAsync();    
        }
        public async Task<CanSubAllocation> FindSingleCanSubAllocation(Expression<Func<CanSubAllocation, bool>> predicate)
        {
            return await _context.CanSubAllocations
                .Include(csa => csa.CanAllocation)
                    .ThenInclude(ca => ca.Can)
                        .ThenInclude(c => c.Division)
                            .ThenInclude(d => d.Institute)
                .Include(csa => csa.CanAllocation)
                    .ThenInclude(ca => ca.Branch)
                        .ThenInclude(b => b.Division)
                            .ThenInclude(d => d.Institute)
                .Where(predicate)
                .SingleOrDefaultAsync(csa => csa.Status == Status.Active);    
        }
    }
}