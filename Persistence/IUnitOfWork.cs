using System;
using System.Threading.Tasks;

namespace Trips.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IOrganizationRepository Organization { get; }
        IAllocationRepository Allocations { get; }
        IUserRoleRepository UserRoles { get; }
        Task<int> Complete();
    }
}