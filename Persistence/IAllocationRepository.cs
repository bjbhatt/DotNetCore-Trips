using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Trips.Models;

namespace Trips.Persistence
{
    public interface IAllocationRepository
    {
        Task<ICollection<CanAllocation>> ListCanAllocation();
        Task<CanAllocation> GetCanAllocation(int canAllocationId); 
        void AddCanAllocation(CanAllocation canAllocation);
        Task<ICollection<CanAllocation>> FindCanAllocations(Expression<Func<CanAllocation, bool>> predicate);
        Task<CanAllocation> FindSingleCanAllocation(Expression<Func<CanAllocation, bool>> predicate);

        Task<ICollection<CanSubAllocation>> ListCanSubAllocation();
        Task<CanSubAllocation> GetCanSubAllocation(int canSubAllocationId); 
        void AddCanSubAllocation(CanSubAllocation canSubAllocation);
        Task<ICollection<CanSubAllocation>> FindCanSubAllocations(Expression<Func<CanSubAllocation, bool>> predicate);
        Task<CanSubAllocation> FindSingleCanSubAllocation(Expression<Func<CanSubAllocation, bool>> predicate);

    }
}