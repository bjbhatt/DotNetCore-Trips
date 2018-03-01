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
        private IQueryable<CanAllocation> _canAllocations 
        {
            get 
            {
                return _context.CanAllocations
                    .Include(ca => ca.CanSubAllocations)
                    .Include(ca => ca.Division)
                        .ThenInclude(d => d.Institute)
                    .Include(ca => ca.Can)
                        .ThenInclude(c => c.Division)
                            .ThenInclude(d => d.Institute)
                    .Include(ca => ca.Branch)
                        .ThenInclude(b => b.Division)
                            .ThenInclude(d => d.Institute)
                    .Where(ca => ca.Status == Status.Active);
            }
        }
        public async Task<ICollection<CanAllocation>> ListCanAllocation() 
        {
            return await _canAllocations.ToListAsync();    
        } 
        public async Task<CanAllocation> GetCanAllocation(int canAllocationId) 
        {
            return await _canAllocations.SingleOrDefaultAsync(ca => ca.CanAllocationId == canAllocationId);    
        } 
        public async void AddCanAllocation(CanAllocation canAllocation) 
        {
            await _context.CanAllocations.AddAsync(canAllocation);
        }
        public async Task<ICollection<CanAllocation>> FindCanAllocations(Expression<Func<CanAllocation, bool>> predicate) 
        {
            return await _canAllocations.Where(predicate).ToListAsync();    
        } 
        public async Task<CanAllocation> FindSingleCanAllocation(Expression<Func<CanAllocation, bool>> predicate) 
        {
            return await _canAllocations.SingleOrDefaultAsync(predicate);    
        } 
        
        private IQueryable<CanSubAllocation> _canSubAllocations 
        {
            get 
            {
                return _context.CanSubAllocations
                    .Include(csa => csa.CanAllocation)
                        .ThenInclude(ca => ca.Can)
                            .ThenInclude(c => c.Division)
                                .ThenInclude(d => d.Institute)
                    .Include(csa => csa.CanAllocation)
                        .ThenInclude(ca => ca.Branch)
                            .ThenInclude(b => b.Division)
                                .ThenInclude(d => d.Institute)
                    .Where(csa => csa.Status == Status.Active);
            }
        }
        public async Task<ICollection<CanSubAllocation>> ListCanSubAllocation()
        {
            return await _canSubAllocations.ToListAsync();    
        }
        public async Task<CanSubAllocation> GetCanSubAllocation(int canSubAllocationId)
        {
            return await _canSubAllocations.SingleOrDefaultAsync(csa => csa.CanAllocationId == canSubAllocationId);    
        }
        public async void AddCanSubAllocation(CanSubAllocation canSubAllocation)
        {
            await _context.CanSubAllocations.AddAsync(canSubAllocation);
        }
        public async Task<ICollection<CanSubAllocation>> FindCanSubAllocations(Expression<Func<CanSubAllocation, bool>> predicate)
        {
            return await _canSubAllocations.Where(predicate).ToListAsync();    
        }
        public async Task<CanSubAllocation> FindSingleCanSubAllocation(Expression<Func<CanSubAllocation, bool>> predicate)
        {
            return await _canSubAllocations.SingleOrDefaultAsync(predicate);
        }
    }
}